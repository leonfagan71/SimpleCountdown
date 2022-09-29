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
    public partial class ControlForm : Form {
        public ControlForm() {
            InitializeComponent();
        }
        DateTime currentAddTime = new DateTime();
        Timer timerPreviewAddTime = new Timer();

        private void Form1_Load(object sender, EventArgs e) {
            timerPreviewAddTime.Interval = 50;
            timerPreviewAddTime.Tick += TimerPreviewAddTime_Tick;
            timerPreviewAddTime.Start();
        }

        private void TimerPreviewAddTime_Tick(object sender, EventArgs e) {
            label7.Text = currentAddTime.ToString("HH:mm:ss");
            label2.Text = currentAddTime.ToString("HH");
            label3.Text = currentAddTime.ToString("mm");
            label4.Text = currentAddTime.ToString("ss");
            if (currentAddTime.Hour <= 0) {
                btn_delTimeHH.Visible = false;
            } else {
                btn_delTimeHH.Visible = true;
            }
            if (currentAddTime.Hour <= 9) {
                btn_delTimeHH_10.Visible = false;
            } else {
                btn_delTimeHH_10.Visible = true;
            }

            if (currentAddTime.Minute <= 0) {
                btn_delTimeMM.Visible = false;
            } else {
                btn_delTimeMM.Visible = true;
            }
            if (currentAddTime.Minute <= 9) {
                btn_delTimeMM_10.Visible = false;
            } else {
                btn_delTimeMM_10.Visible = true;
            }

            if (currentAddTime.Second <= 0) {
                btn_delTimeSS.Visible = false;
            } else {
                btn_delTimeSS.Visible = true;
            }
            if (currentAddTime.Second <= 9) {
                btn_delTimeSS_10.Visible = false;
            } else {
                btn_delTimeSS_10.Visible = true;
            }

            var ticks = currentAddTime.Ticks;
            if (ticks >= 0) {
                DateTime end = Program.end_time.Add(TimeSpan.FromTicks(ticks));
                long diffTicks = (end - DateTime.Now).Ticks;
                if (diffTicks > 1) {
                    var datetimediff = new DateTime(diffTicks);
                    var TimeTook = datetimediff.ToString("HH:mm:ss");
                    if (TimeTook != null) label9.Text = TimeTook;

                    //add check for timetook, if that's going to lapse remaining time, then don't show the del time button.
                    //
                    long diffTicksTot = (Program.end_time.Add(new TimeSpan(currentAddTime.Ticks*-1)) - DateTime.Now).Ticks;
                    if (diffTicksTot > 1) {
                        //var datetimediffTot = new DateTime(diffTicksTot);
                        //Console.WriteLine(datetimediffTot.ToString("HH:mm:ss"));//Remaining time for del button
                        btn_del.Enabled = true;
                    } else {
                        btn_del.Enabled = false;
                    }
                    btn_set.Enabled = true;
                } else {
                    btn_del.Enabled = false;
                    btn_set.Enabled = false;
                }
            } else {
                label9.Text = "Timer Invalid";
                btn_del.Visible = false;
            }
        }

        private void btn_opnclock_Click(object sender, EventArgs e) {
            ClockCountdownFrm clock = new ClockCountdownFrm();
            clock.Show();
        }

        private void btn_set_Click(object sender, EventArgs e) {
            //add the hh,mm,ss to the time
            Program.end_time=Program.end_time.Add(new TimeSpan(currentAddTime.Ticks));
            currentAddTime = new DateTime();
        }

        private void btn_start_Click(object sender, EventArgs e) {
            Program.end_time = DateTime.Now.AddMinutes(1);
        }
        
        private void btn_addTimeHH_10_Click(object sender, EventArgs e) {
            currentAddTime=currentAddTime.AddHours(10);
        }

        private void btn_addTimeHH_Click(object sender, EventArgs e) {
            currentAddTime = currentAddTime.AddHours(1);
        }

        private void btn_addTimeMM_10_Click(object sender, EventArgs e) {
            currentAddTime = currentAddTime.AddMinutes(10);
        }

        private void btn_addTimeMM_Click(object sender, EventArgs e) {
            currentAddTime = currentAddTime.AddMinutes(1);
        }

        private void btn_addTimeSS_10_Click(object sender, EventArgs e) {
            currentAddTime = currentAddTime.AddSeconds(10);
        }

        private void btn_addTimeSS_Click(object sender, EventArgs e) {
            currentAddTime = currentAddTime.AddSeconds(1);
        }

        private void btn_delTimeHH_Click(object sender, EventArgs e) {
            currentAddTime = currentAddTime.AddHours(-1);
        }

        private void btn_delTimeHH_10_Click(object sender, EventArgs e) {
            currentAddTime = currentAddTime.AddHours(-10);
        }

        private void btn_delTimeMM_Click(object sender, EventArgs e) {
            currentAddTime = currentAddTime.AddMinutes(-1);
        }

        private void btn_delTimeMM_10_Click(object sender, EventArgs e) {
            currentAddTime = currentAddTime.AddMinutes(-10);
        }

        private void btn_delTimeSS_Click(object sender, EventArgs e) {
            currentAddTime = currentAddTime.AddSeconds(-1);
        }

        private void btn_delTimeSS_10_Click(object sender, EventArgs e) {
            currentAddTime = currentAddTime.AddSeconds(-10);
        }

        private void btn_del_Click(object sender, EventArgs e) {
            Program.end_time=Program.end_time.Add(new TimeSpan(currentAddTime.Ticks*-1));
            currentAddTime = new DateTime();
        }
    }
}
