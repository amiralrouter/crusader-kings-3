using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Crusader_Kings_3.Component {
    /// <summary>
    /// TraitListComponent.xaml etkileşim mantığı
    /// </summary>
    public partial class TraitListComponent : UserControl {
  

        public TraitListComponent() {
            InitializeComponent(); 
            LoadProfiles();
        }


        Traits playerTraits;



        public class TraitListItem{
            public ListViewItem listViewItem;
            public CheckBox checkBox;
            public StackPanel stackPanel;
            public System.Windows.Controls.Image image;
            public Label label;
            public Trait trait;
            public int i;
        }
        public List<TraitListItem> traitListItems = new List<TraitListItem>();
        void FillTraitItems() {
            foreach(Trait trait in Utils.Traits) {
                TraitListItem item = new TraitListItem();
                item.listViewItem = new ListViewItem(); 
                item.checkBox = new CheckBox();
                item.checkBox.VerticalAlignment = VerticalAlignment.Center;
                item.checkBox.IsChecked = false;
                item.checkBox.Visibility = Visibility.Visible;
                item.stackPanel = new StackPanel();
                item.stackPanel.Orientation = Orientation.Horizontal;
                item.image = new System.Windows.Controls.Image();
                item.image.Source = trait.logo;
                item.image.Width = 30;
                item.image.Height = 30;
                item.label = new Label();
                item.label.Content = trait.id;
                item.label.VerticalContentAlignment = VerticalAlignment.Center;
                item.label.HorizontalContentAlignment = HorizontalAlignment.Left;
                item.label.HorizontalAlignment = HorizontalAlignment.Stretch;
                item.label.Foreground = System.Windows.Media.Brushes.Black;
                item.trait = trait;
                item.i = traitListItems.Count;

                // add Label and Image to stackpanel
                item.stackPanel.Children.Add(item.image);
                item.stackPanel.Children.Add(item.label);
                // add stackpanel to checkbox
                item.checkBox.Content = item.stackPanel;
                // add checkbox to listviewitem
                item.listViewItem.Content = item.checkBox;
                // add listviewitem to listview
                ListView1.Items.Add(item.listViewItem);
                traitListItems.Add(item);
                 
                // add checbox change with click
                item.checkBox.Click += (s, e) => {
                    UpgradeTraits();
                };
            }
        }


 
        public void SetPlayerTraits(Traits playerTraits) {
            if (traitListItems.Count == 0)
                FillTraitItems();

            traitListItems.ForEach(item => {
                item.checkBox.IsChecked = false;
            });
            this.playerTraits = playerTraits;
            this.playerTraits.list.ToList().ForEach(index => traitListItems[index].checkBox.IsChecked = true);
        }

        private List<int> GetSelectedTraitsIds() {
            var checkedItems = traitListItems.Where(item => item.checkBox.IsChecked == true).ToList();
            var checkedIndexes = checkedItems.Select(item => item.i).ToList();
            return checkedIndexes;
        }
        private void UpgradeTraits() { 
            playerTraits.list = GetSelectedTraitsIds().ToArray();
        }


        public void Search_Change(object sender, string e) { 
            traitListItems.ForEach(item => {
                if(e == "" || item.trait.id.Contains(e.ToLower())){ 
                    item.listViewItem.Visibility = Visibility.Visible;
                }
                else {
                    item.listViewItem.Visibility = Visibility.Collapsed;
                } 
            }); 
        }

        private void SaveProfile_Click(object sender, RoutedEventArgs e) {
            SaveProfile(); 
        }
        private void SaveProfile() {
            string profile_name = Interaction.InputBox("Enter a name for this profile", "Save Profile", "", -1, -1);
            if (profile_name == "") 
                return;  
            string ids = string.Join(",", GetSelectedTraitsIds().ToArray()); 
            TraitProfilesList.Items.Insert(0, profile_name + "|" + ids);
            SaveProfilesToFile(); 
        }
        private void SaveProfilesToFile() { 
            string lines = string.Join("\n", TraitProfilesList.Items.Cast<string>().ToArray());  
            System.IO.File.WriteAllText("trait_profiles.txt", lines); 
        }
        private void RefreshProfile_Click(object sender, RoutedEventArgs e) {
            LoadProfiles();
        }
        private void LoadProfiles() {
            TraitProfilesList.Items.Clear();
            string filename = "trait_profiles.txt";
            if (!System.IO.File.Exists(filename))
                return; 
            string[] lines = System.IO.File.ReadAllLines(filename);
            foreach (string line in lines) {
                TraitProfilesList.Items.Add(line);
            }
        }
        private void DeleteProfile_Click(object sender, RoutedEventArgs e) { 
            if (MessageBox.Show("Are you sure you want to delete this profile?", "Delete Profile", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.No)
                return; 
            if (TraitProfilesList.SelectedIndex != -1) { 
                TraitProfilesList.Items.Remove(TraitProfilesList.SelectedItem);
            }
            SaveProfilesToFile();
        }
        private void ApplyProfile_Click(object sender, RoutedEventArgs e) { 
            if (TraitProfilesList.SelectedIndex != -1) {
                string[] lines = TraitProfilesList.SelectedItem.ToString().Split('|');
                string[] ids = lines[1].Split(','); 
                int[] trait_ids = Array.ConvertAll(ids, int.Parse);
                playerTraits.list = trait_ids;
            }
        }
    }
}
