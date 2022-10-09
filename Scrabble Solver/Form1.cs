using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace Scrabble_Solver
{

    public partial class Form1 : Form
    {
        readonly Trie wordTrie = new Trie();
        private readonly BackgroundWorker backgroundWorker = new BackgroundWorker();
        private List<ListViewItem> listViewItems;
        public Form1()
        {
            InitializeComponent();
            listView.View = View.Details;
            backgroundWorker.DoWork += BackgroundWorker_DoWork;
            backgroundWorker.RunWorkerCompleted += BackgroundWorker_RunWorkerCompleted;
            backgroundWorker.WorkerSupportsCancellation = true;

            // initialize wordTrie at start of application for efficient queries
            foreach (string line in File.ReadLines(Constants.ScrabbleWordsPath))
            {
                wordTrie.Insert(line.TrimEnd('\r', '\n'));
            }
        }

        private static int GetScore(string word)
        {
            return word.Select(c => Constants.Points[c]).Sum();
        }

        // call on backgroundWorker to update list when text is update
        private void TextBox1_TextChanged(object sender, EventArgs e)
        {
            backgroundWorker.CancelAsync();
            while (backgroundWorker.IsBusy)
            {
                System.Threading.Thread.Sleep(100);
                Application.DoEvents();
            }
            backgroundWorker.RunWorkerAsync();
        }

        // for valid query, populate listViewItems with the best {Constants.NumberOfWordsToReturn} words
        // for invalid query, populate listViewItems with the invalid symbols from the query
        private void BackgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            listViewItems = new List<ListViewItem>();

            // generate Dictionary containing the number of occurrences of each letter
            Dictionary<char, int> letters = new Dictionary<char, int>();
            bool validQuery = true;
            foreach (char c in textBox.Text.ToUpper())
            {
                // handle invalid characters
                if (!Constants.Points.ContainsKey(c) && c != Constants.Blank)
                {
                    validQuery = false;
                    listViewItems.Add(new ListViewItem(new string[] { c.ToString(), "Invalid Symbol" }));
                }
                else if (!letters.ContainsKey(c))
                {
                    letters[c] = 1;
                }
                else
                {
                    letters[c]++;
                }
            }

            // if valid query, add best words to listViewItems
            if (validQuery)
            {
                // get solutions from wordTrie, pair each word with its score, sort by score descending, break ties alphabetically
                var words = wordTrie.Solve(letters).Select(word => (count: GetScore(word), word)).ToList().OrderByDescending(x => x.count).ThenBy(x => x.word);
                foreach (var (count, word) in words.Take(Constants.NumberOfWordsToReturn))
                {
                    listViewItems.Add(new ListViewItem(new string[] { count.ToString(), word }));
                }
            }
        }

        // when backgroundWorker finishes, repopulate listView
        private void BackgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            listView.Items.Clear();
            foreach (var entry in listViewItems)
            {
                listView.Items.Add(entry);
            }
        }

        // make Ctrl-Backspace work properly
        private void TextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.Back)
            {
                e.SuppressKeyPress = true;
                SendKeys.Send("+{LEFT}{DEL}");
            }
        }
    }
}