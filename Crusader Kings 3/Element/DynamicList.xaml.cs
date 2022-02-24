using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq; 
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace Crusader_Kings_3.Element {
    public partial class DynamicList : UserControl {
        public class Item {
            public ListViewItem listViewItem;
            public CheckBox checkBox;
            public StackPanel stackPanel;
            public System.Windows.Controls.Image image;
            public Label label;
            public Trait trait;
            public int i;
        }
        public List<Item> items = new List<Item>();

        public DynamicList() {
            InitializeComponent();
            RefreshCache();
        }

        public void AddItem(ImageSource imageSource, string content) {
            Item item = new Item();
            item.listViewItem = new ListViewItem();
            item.checkBox = new CheckBox();
            item.checkBox.VerticalAlignment = VerticalAlignment.Center;
            item.checkBox.IsChecked = false;
            item.checkBox.Visibility = Visibility.Visible;
            item.stackPanel = new StackPanel();
            item.stackPanel.Orientation = Orientation.Horizontal;
            item.image = new Image();
            item.image.Source = imageSource;
            item.image.Width = 30;
            item.image.Height = 30;
            item.label = new Label();
            item.label.Content = content;
            item.label.VerticalContentAlignment = VerticalAlignment.Center;
            item.label.HorizontalContentAlignment = HorizontalAlignment.Left;
            item.label.HorizontalAlignment = HorizontalAlignment.Stretch;
            item.label.Foreground =  Brushes.Black; 
            item.i = items.Count;
             
            item.stackPanel.Children.Add(item.image);
            item.stackPanel.Children.Add(item.label);
      
            item.checkBox.Content = item.stackPanel;
    
            item.listViewItem.Content = item.checkBox;
     
            ListView1.Items.Add(item.listViewItem);
            items.Add(item);
             
            item.checkBox.Click += (s, e) => {
                OnCheckboxClicked();
            };
        }
        public void OnFilterChanged(object sender, string e) {
            items.ForEach(item => {
                if (e == "" || item.trait.id.Contains(e.ToLower())) {
                    item.listViewItem.Visibility = Visibility.Visible;
                }
                else {
                    item.listViewItem.Visibility = Visibility.Collapsed;
                }
            });
        }
        public void UnSelectAll() {
            items.ForEach(item => {
                item.checkBox.IsChecked = false;
            });
        }
        public void SetSelecteds(int[] indexes) { 
            UnSelectAll();
            foreach (int index in indexes) {
                items[index].checkBox.IsChecked = true;
            }
        }
        public int[] GetSelecteds() {
            List<int> selecteds = new List<int>();
            foreach (Item item in items) {
                if (item.checkBox.IsChecked == true) {
                    selecteds.Add(item.i);
                }
            }
            return selecteds.ToArray();
        }

        public event EventHandler<int[]> Update; 
        private void OnCheckboxClicked() {
            if (Update != null)
                Update(this, GetSelecteds());
        }




        private string GetCacheFilePath(){ 
            string fileName = this.GetType().Name + ".xml"; 
            return System.IO.Path.Combine(Environment.CurrentDirectory, fileName);  
        }
        public void AddNewCache_Click(object sender, RoutedEventArgs e) {
            AddNewCache();
        }
        private void AddNewCache() {
            string profile_name = Interaction.InputBox("Enter a name for this profile", "Save Profile", "", -1, -1);
            if (profile_name == "")
                return;
            string ids = string.Join(",", GetSelecteds().ToArray());
            CacheList.Items.Insert(0, profile_name + "|" + ids);
            SaveCacheToFile();
        }
        private void SaveCacheToFile() {
            string lines = string.Join("\n", CacheList.Items.Cast<string>().ToArray());
            System.IO.File.WriteAllText(GetCacheFilePath(), lines);
        }
        public void RefreshCache_Click(object sender, RoutedEventArgs e) {
            RefreshCache();
        }
        private void RefreshCache() {
            CacheList.Items.Clear();
            string filename = GetCacheFilePath();
            if (!System.IO.File.Exists(filename))
                return;
            string[] lines = System.IO.File.ReadAllLines(filename);
            foreach (string line in lines) {
                CacheList.Items.Add(line);
            }
        }
        public void DeleteCache_Click(object sender, RoutedEventArgs e) {
            if (MessageBox.Show("Are you sure you want to delete this profile?", "Delete Profile", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.No)
                return;
            if (CacheList.SelectedIndex != -1) {
                CacheList.Items.Remove(CacheList.SelectedItem);
            }
            SaveCacheToFile();
        }
        private void ApplyCache_Click(object sender, RoutedEventArgs e) {
            if (CacheList.SelectedIndex == -1)
                return;
            string[] parts = CacheList.SelectedItem.ToString().Split('|');
            if (parts.Length != 2)
                return;

            int[] ids = Array.ConvertAll(parts[1].Split(','), int.Parse);

            SetSelecteds(ids);
            Update(this, GetSelecteds());
        }








 
    }
}
