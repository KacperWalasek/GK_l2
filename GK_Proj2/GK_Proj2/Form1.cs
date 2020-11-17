using GK_Projekt2.Shapes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GK_Projekt2.AET_entry.factories;

namespace GK_Projekt2
{
    public enum Mode
    {
        Edit, Delete, Draw, Add, Change
    }
    public partial class Form1 : Form
    {
        Bitmap stableBitmap;
        Bitmap bitmap;
        List<Polygon> stablePolygons;
        Polygon activePolygon;
        Mode mode;
        AET_factory fillFactory;
        System.Diagnostics.Stopwatch stopwatch;

        public Form1()
        {
            stopwatch = new System.Diagnostics.Stopwatch();
            stablePolygons = new List<Polygon>();
            InitializeComponent();
            textureDialog.Filter = "Image Files(*.BMP; *.JPG; *.PNG; *.GIF)| *.PNG; *.BMP; *.JPG; *.GIF | All files(*.*) | *.*";
            stableBitmap = new Bitmap(pictureBox.Width, pictureBox.Height);
            Clear();
            bitmap = (Bitmap)stableBitmap.Clone();
            DrawEngine.sun.Render(bitmap);
            pictureBox.Image = bitmap;
            UpdateFillMode();
        }
        private void Clear() 
        {
            Graphics g = Graphics.FromImage(stableBitmap);
            g.Clear(Color.White);
        }
        private void DeapRefresh() 
        {
            Clear();
            foreach (Polygon polygon in stablePolygons)
                polygon.Render(stableBitmap);
            DrawEngine.sun.Render(stableBitmap);
            RefreshActive();
        }
        private void RefreshActive()
        {
            bitmap = (Bitmap)stableBitmap.Clone();
            activePolygon?.Render(bitmap);
            pictureBox.Image = bitmap;
        }

        private void pictureBox_MouseClick(object sender, MouseEventArgs e)
        {
            if (activePolygon == null)
            {
                if (DrawEngine.sun.Clicked(e.Location))
                {
                    DeapRefresh();
                    return;
                }
                if(Draw.Checked)
                    activePolygon = new Polygon(e.Location, VertexPanel.BackColor, fillPanel.BackColor, fillFactory);
                else
                {
                    foreach(Polygon polygon in stablePolygons)
                        if(polygon.Contains(e.Location))
                        {
                            if (changeColor.Checked)
                                polygon.ChangeClick(e.Location, fillFactory, fillPanel.BackColor, VertexPanel.BackColor );
                            polygon.Click(e.Location, mode, VertexPanel.BackColor);
                            if (polygon.Active)
                            {
                                stablePolygons.Remove(polygon);
                                activePolygon = polygon;
                            }
                            DeapRefresh();
                            break;
                        }
                }
            }
            else
            {
                if (DrawEngine.sun.Clicked(e.Location))
                {
                    DeapRefresh();
                    return;
                }
                activePolygon.Click(e.Location, mode, VertexPanel.BackColor);
                if (!activePolygon.Active)
                {
                    stablePolygons.Add(activePolygon);
                    activePolygon = null;
                    DeapRefresh();
                }
                RefreshActive();
            }
        }

        private void pictureBox_MouseMove(object sender, MouseEventArgs e)
        {
            if (DrawEngine.sun.moving)
            {
                DrawEngine.sun.MouseMove(e.Location);
                DeapRefresh();
            }
            if (activePolygon != null)
            {
                activePolygon.MouseMove(e.Location);
                RefreshActive();
            }
        }

        private void CheckedChangedAction(object sender, EventArgs e)
        {
            CheckBox box = (CheckBox)sender;
            if (activePolygon != null)
                box.Checked = false;

            if (box.Checked)
            {
                box.Enabled = false;
                if (Draw != box)
                    Draw.Checked = false;
                if (Edit != box)
                    Edit.Checked = false;
                if (Delete != box)
                    Delete.Checked = false;
                if (Add != box)
                    Add.Checked = false;
                if (changeColor != box)
                    changeColor.Checked = false;
            }
            else
                box.Enabled = true;
            UpdateMode();
        }
        private void CheckedChangedFillMode(object sender, EventArgs e)
        {
            CheckBox box = (CheckBox)sender;
            if (activePolygon != null)
                box.Checked = false;
            if (box == textureBox && box.Checked)
                if (textureDialog.ShowDialog() != DialogResult.OK)
                {
                    box.Checked = false;
                    return;
                }
            if (box.Checked)
            {
                box.Enabled = false;
                if (fillColorBox != box)
                    fillColorBox.Checked = false;
                if (textureBox != box)
                    textureBox.Checked = false;
                if (vertexInterpolationBox != box)
                    vertexInterpolationBox.Checked = false;
            }
            else
                box.Enabled = true;
            UpdateFillMode();
        }
        private void UpdateMode()
        {
            mode = Draw.Checked ? Mode.Draw :
                   Edit.Checked ? Mode.Edit :
                   Add.Checked ? Mode.Add :
                   Delete.Checked ? Mode.Delete :
                   changeColor.Checked ? Mode.Change : mode;
        }
        private void UpdateFillMode()
        {
            fillFactory = fillColorBox.Checked ? new AET_factory_fill() :
                       vertexInterpolationBox.Checked ? new AET_factory_interpol() :
                       textureBox.Checked ?
                        (FillComboBox.SelectedIndex == 0 ? (AET_factory)new AET_factory_imageTexture(new Bitmap( textureDialog.FileName)) :
                        new AET_factory_heigthMap(new Bitmap(textureDialog.FileName))) : fillFactory;
        }

        private void fillPanel_Click(object sender, EventArgs e)
        {
            fillColorDialog.ShowDialog();
            fillPanel.BackColor = fillColorDialog.Color;
        }

        private void VertexPanel_Click(object sender, EventArgs e)
        {
            vertexColorDialog.ShowDialog();
            VertexPanel.BackColor = vertexColorDialog.Color;
        }

        private void FillComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateFillMode();
        }

        private void SunPanel_Click(object sender, EventArgs e)
        {
            sunColorDialog.ShowDialog();
            SunPanel.BackColor = sunColorDialog.Color;
        }
        private void UpdateSun()
        {
            DrawEngine.sun.ks = float.Parse(KsBox.Text);
            DrawEngine.sun.kd = float.Parse(KdBox.Text);
            DrawEngine.sun.height = int.Parse( HeightBox.Text);
            DrawEngine.sun.color = SunPanel.BackColor;
            DeapRefresh();
        }

        private void apply_Click(object sender, EventArgs e)
        {
            UpdateSun();
        }


        private void MoveBox_CheckedChanged(object sender, EventArgs e)
        {
            if ((sender as CheckBox).Checked)
            {
                timer1.Interval = 1000 / int.Parse(fpsBox.Text);
                timer1.Enabled = true;
                foreach (Polygon p in stablePolygons)
                {
                    p.startMoving(int.Parse(minVelocity.Text), int.Parse(maxVelocity.Text));
                    p.Move(bitmap.Width, bitmap.Height);
                }
                stopwatch.Start();
            }
            else
            {
                timer1.Enabled = false;
                stopwatch.Stop();
            }    
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            //int v = int.Parse(VelocityBox.Text)/ int.Parse(fpsBox.Text);
            foreach (Polygon p in stablePolygons)
                p.Move(stableBitmap.Width, pictureBox.Height);
            DeapRefresh();
            fpsLabel.Text = ((int)(1 / stopwatch.Elapsed.TotalSeconds)).ToString();
            stopwatch.Restart();
        }
    }
}
