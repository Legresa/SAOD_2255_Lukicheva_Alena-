using Microsoft.Msagl.Drawing;
using Microsoft.Msagl.GraphViewerGdi;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class ViewForm : Form
    {
        public ViewForm(Graph graph)
        {
            InitializeComponent();
            GViewer gViewer = new GViewer(); 
            graph.Attr.LayerDirection = LayerDirection.None;
            gViewer.Graph = graph;
            gViewer.Dock = DockStyle.Fill;
            gViewer.ToolBarIsVisible = false;
            gViewer.Enabled = false;
            Controls.Add(gViewer);
            ResumeLayout();
        }
    }
}
