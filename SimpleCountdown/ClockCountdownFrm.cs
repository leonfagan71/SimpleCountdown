using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SimpleCountdown {
    public partial class ClockCountdownFrm : Form {
        Timer countdownTimer = new Timer();
        public ClockCountdownFrm() {
            InitializeComponent();
            countdownTimer.Tick += CountdownTimer_Tick;
            countdownTimer.Interval = 10;
        }

        private void CountdownTimer_Tick(object sender, EventArgs e) {
            if (Program.end_time != null) {
                if (Program.end_time> DateTime.Now) {
                    var datetimediff = new DateTime((Program.end_time - DateTime.Now).Ticks);
                    var TimeTook = datetimediff.ToString("HH:mm:ss");
                    if (TimeTook != null) label1.Text = TimeTook;
                } else {
                    label1.Text = "00:00:00";
                }
            } else {
                label1.Text = "00:00:00";
            }
        }

        private void ClockCountdownFrm_Load(object sender, EventArgs e) {
            countdownTimer.Start();
        }
    }
}
