/*Made by Cecília Takeda using ffmpeg
* 21/09/2020 Mom I love you thank you 
*/
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Img2Video
{

    public partial class Screen : Form
    {

        public Screen()
        {
            InitializeComponent();

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //sorry for this string lol
            string _colors = "Aqua,Azure,Beige,Black,Blue,Brown,Crimson,Cyan,DeepPink,ForestGreen,Fuchsia,Gold," +
                "Gray,Green,HotPink,Indigo,Ivory,Magenta,Maroon,Navy,Orange,Pink,Purple,Red,Salmon,Silver,SkyBlue," +
                "Snow,SteelBlue,Teal,Tomato,Turquoise,Violet,White,Yellow";
            _textColor.Items.AddRange( _colors.Split(',').ToArray());
            _textColor.SelectedItem = "Black";
            _textBorder.Items.Add("Black");
            _textBorder.Items.Add("White");
            _textBorder.Items.Add("No Border");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //button1.Hide();

            //FPS + input file
            bool _vf = false;
            string _input = "-y -framerate " + fps.Text + " -i img\\%03d." + imgType.Text;
            //song
            if (_song.Checked) _input += " -i song.mp3 -shortest";
            //Resolution
            if (_resX.Text != "" && _resY.Text != "")
            {
                _vf = true;
                _input += " -vf \"scale=" + _resX.Text + ":" + _resY.Text;
            }
            //Text
            if (_text.Text != "")
            {
                //it shouldn't -vf twice and should : in case scaling
                _input += (!_vf) ? " -vf \"drawtext=" : ":drawtext=";                 
                _vf = false;
                //bordercolor
                switch(_textBorder.SelectedIndex)
                {
                    case 0:
                        _input += "borderw=2:";
                        break;
                    case 1:
                        _input += "borderw=2:bordercolor=white:";
                        break;
                    default:
                        break;
                }
                //text color
                _input += "fontcolor=" + _textColor.Text + ":";
                //font
                _input += "font=" + _textFont.Text + ":";
                //fontsize
                _input += "fontsize=" + _fontSize.Text + ":";
                //text
                _input += "text='" + _text.Text + "':";
                //XY
                if (_textX.Text == "" && _textY.Text == "") _input += "x=(w-text_w)/2:y=(h-text_h-line_h)/2\"";
                else _input += "x=" + _textX.Text + ":y=" + _textY.Text + "\"";

            }
            if (_vf) _input += "\"";
            _input += " -c:v h264 -r " + fps.Text + " video.mp4";

            Process _ffmpeg = new Process
            {
                StartInfo =
                {
                    FileName = "ffmpeg.exe",
                    Arguments = _input,
                    UseShellExecute = false,
                    CreateNoWindow = true,
                    RedirectStandardInput = true,
                }
            };
            _ffmpeg.Start();
            _ffmpeg.WaitForExit();
            MessageBox.Show("Success", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

        }

    }

   
}
