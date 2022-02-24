using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
    /// Player.xaml etkileşim mantığı
    /// </summary>
    public partial class PlayerComponent : UserControl {

        public Player player;

        public PlayerComponent() {
            InitializeComponent();

            Utils.CreateTimer(1000, () => {
                if(player == null)
                    return;
                
                ID.Value = player.name;
                Name.Value = player.name;
                CultureID.Value = player.culture_id.ToString();
                FaithID.Value = player.faith_id.ToString();
                DynastyID.Value = player.dynasty_id.ToString();
                BirthDate.Value = player.birth_date.ToString();
                DNAHex.Value = player.dna.hex;

                Gold.Value = player.gold.ToString();
                Prestige.Value = player.prestige.ToString();
                Piety.Value = player.piety.ToString();
                Stress.Value = player.stress.ToString();
                Dread.Value = player.dread.ToString();
                Fertility.Value = player.fertility.ToString();
                MaxFertility.Value = player.max_fertility.ToString();
                Health.Value = player.health.ToString();
                MaxHealth.Value = player.max_health.ToString();

                BaseStatsDiplomacy.Value = player.base_stats.diplomacy.ToString();
                BaseStatsMartial.Value = player.base_stats.martial.ToString();
                BaseStatsStewardship.Value = player.base_stats.stewardship.ToString();
                BaseStatsIntrigue.Value = player.base_stats.intrigue.ToString();
                BaseStatsLearning.Value = player.base_stats.learning.ToString();
                BaseStatsProwess.Value = player.base_stats.prowess.ToString();

                ModifiedStatsDiplomacy.Value = player.modified_stats.diplomacy.ToString();
                ModifiedStatsMartial.Value = player.modified_stats.martial.ToString();
                ModifiedStatsStewardship.Value = player.modified_stats.stewardship.ToString();
                ModifiedStatsIntrigue.Value = player.modified_stats.intrigue.ToString();
                ModifiedStatsLearning.Value = player.modified_stats.learning.ToString();
                ModifiedStatsProwess.Value = player.modified_stats.prowess.ToString();

                LifestyleDiplomacy.Value = player.lifestyle.diplomacy.ToString();
                LifestyleMartial.Value = player.lifestyle.martial.ToString();
                LifestyleStewardship.Value = player.lifestyle.stewardship.ToString();
                LifestyleIntrigue.Value = player.lifestyle.intrigue.ToString();
                LifestyleLearning.Value = player.lifestyle.learning.ToString();

                FocusType.Value = player.focus.type.ToString();
                FocusStartDate.Value = player.focus.start_date.ToString();
                FocusEndDate.Value = player.focus.end_date.ToString();
                FocusChanges.Value = player.focus.changes.ToString();
                FocusProgress.Value = player.focus.progress.ToString();

                TraitList.SetPlayerTraits(player.traits);
            });
        }

 

        private void ID_Change(object sender, string e) { 
            // player.id = e;
        }

        private void Name_Change(object sender, string e) {
            if(player != null)
                player.name = e;
        }

        private void CultureID_Change(object sender, string e) {
            if (player != null)
                player.culture_id = int.Parse(e);
        }

        private void FaithID_Change(object sender, string e) {
            if (player != null)
                player.faith_id = int.Parse(e);
        }

        private void DynastyID_Change(object sender, string e) { 
            if (player != null)
                player.dynasty_id = int.Parse(e);
        }

        private void BirthDate_Change(object sender, string e) { 
            // if (player != null)
            //     player.birth_date = int.Parse(e);
        }

        private void DNAHex_Change(object sender, string e) { 
            // if (player != null)
            //     player.dna_hex = e;
        }

        private void Gold_Change(object sender, string e) { 
            if (player != null)
                player.gold = int.Parse(e);
        }

        private void Prestige_Change(object sender, string e) { 
            if (player != null)
                player.prestige = int.Parse(e);
        }

        private void Piety_Change(object sender, string e) { 
            if (player != null)
                player.piety = int.Parse(e);
        }

        private void Stress_Change(object sender, string e) { 
            if (player != null)
                player.stress = int.Parse(e);
        }

        private void Dread_Change(object sender, string e) { 
            if (player != null)
                player.dread = int.Parse(e);
        }

        private void Fertility_Change(object sender, string e) { 
            if (player != null)
                player.fertility = int.Parse(e);
        }

        private void MaxFertility_Change(object sender, string e) { 
            if (player != null)
                player.max_fertility = int.Parse(e);
        }

        private void Health_Change(object sender, string e) { 
            if (player != null)
                player.health = int.Parse(e);
        }

        private void MaxHealth_Change(object sender, string e) { 
            if (player != null)
                player.max_health = int.Parse(e);
        }



        private void BaseStatsDiplomacy_Change(object sender, string e) { 
            if (player != null)
                player.base_stats.diplomacy = int.Parse(e);
        }

        private void BaseStatsMartial_Change(object sender, string e) { 
            if (player != null)
                player.base_stats.martial = int.Parse(e);
        }

        private void BaseStatsStewardship_Change(object sender, string e) { 
            if (player != null)
                player.base_stats.stewardship = int.Parse(e);
        }

        private void BaseStatsIntrigue_Change(object sender, string e) { 
            if (player != null)
                player.base_stats.intrigue = int.Parse(e);
        }

        private void BaseStatsLearning_Change(object sender, string e) { 
            if (player != null)
                player.base_stats.learning = int.Parse(e);
        }

        private void BaseStatsProwess_Change(object sender, string e) { 
            if (player != null)
                player.base_stats.prowess = int.Parse(e);
        }



        private void ModifiedStatsDiplomacy_Change(object sender, string e) { 
            if (player != null)
                player.modified_stats.diplomacy = int.Parse(e);
        }

        private void ModifiedStatsMartial_Change(object sender, string e) { 
            if (player != null)
                player.modified_stats.martial = int.Parse(e);
        }

        private void ModifiedStatsStewardship_Change(object sender, string e) { 
            if (player != null)
                player.modified_stats.stewardship = int.Parse(e);
        }

        private void ModifiedStatsIntrigue_Change(object sender, string e) { 
            if (player != null)
                player.modified_stats.intrigue = int.Parse(e);
        }

        private void ModifiedStatsLearning_Change(object sender, string e) { 
            if (player != null)
                player.modified_stats.learning = int.Parse(e);
        }

        private void ModifiedStatsProwess_Change(object sender, string e) { 
            if (player != null)
                player.modified_stats.prowess = int.Parse(e);
        }
   


        private void LifestyleDiplomacy_Change(object sender, string e) { 
            if (player != null)
                player.lifestyle.diplomacy = int.Parse(e);
        }

        private void LifestyleMartial_Change(object sender, string e) { 
            if (player != null)
                player.lifestyle.martial = int.Parse(e);
        }

        private void LifestyleStewardship_Change(object sender, string e) { 
            if (player != null)
                player.lifestyle.stewardship = int.Parse(e);
        }

        private void LifestyleIntrigue_Change(object sender, string e) { 
            if (player != null)
                player.lifestyle.intrigue = int.Parse(e);
        }

        private void LifestyleLearning_Change(object sender, string e) { 
            if (player != null)
                player.lifestyle.learning = int.Parse(e);
        }



        private void FocusType_Change(object sender, string e) { 
            if (player != null)
                player.focus.type = e;
        }

        private void FocusStartDate_Change(object sender, string e) {  
            if (player != null)
                player.focus.start_date = e;
        }

        private void FocusEndDate_Change(object sender, string e) { 
            if (player != null)
                player.focus.end_date = e;
        }

        private void FocusChanges_Change(object sender, string e) { 
            if (player != null)
                player.focus.changes = int.Parse(e);
        }

        private void FocusProgress_Change(object sender, string e) { 
            if (player != null)
                player.focus.progress = int.Parse(e);
        }
    }
}
