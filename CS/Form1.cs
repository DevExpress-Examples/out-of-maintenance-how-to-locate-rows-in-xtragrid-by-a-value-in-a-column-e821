namespace DevExpress.XtraGrid.Demos.Tutorial.GridPopulation
{
    using System;
    using System.Drawing;
    using System.Collections;
    using System.ComponentModel;
    using System.Windows.Forms;
    using System.Data;
	using System.Data.OleDb;
	using System.Reflection;
	using DevExpress.Utils;
    using DevExpress.XtraGrid;
    using DevExpress.XtraGrid.Views.Grid;
	using DevExpress.XtraGrid.Views.Grid.ViewInfo;
	using DevExpress.XtraGrid.Drawing;
	using DevExpress.XtraGrid.Columns;

    /// <summary>
    ///    Summary description for Form1.
    /// </summary>
    public class Form1 : System.Windows.Forms.Form
    {
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private DevExpress.XtraGrid.GridControl gridControl1;
		private DevExpress.XtraEditors.Repository.PersistentRepository persistentRepository1;
		private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
		private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit repositoryItemTextEdit1;
        private System.Windows.Forms.Button btnFind;
		private string DBFileName;

        public Form1()
        {
            //
            // Required for Windows Form Designer support
			//
			DBFileName = FindingFileName(Application.StartupPath,"Data\\nwind.mdb");
            InitializeComponent();
            //
            // TODO: Add any constructor code after InitializeComponent call
            //
        }

		#region Windows Form Designer generated code
		private void InitializeComponent() {
            System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(Form1));
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.persistentRepository1 = new DevExpress.XtraEditors.Repository.PersistentRepository();
            this.repositoryItemTextEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.btnFind = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.AddRange(new System.Windows.Forms.Control[] {
                                                                                 this.btnFind,
                                                                                 this.label1,
                                                                                 this.label2});
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(590, 32);
            this.panel1.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Location = new System.Drawing.Point(20, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(570, 32);
            this.label1.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.Dock = System.Windows.Forms.DockStyle.Left;
            this.label2.Image = ((System.Drawing.Bitmap)(resources.GetObject("label2.Image")));
            this.label2.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(20, 32);
            this.label2.TabIndex = 1;
            // 
            // gridControl1
            // 
            this.gridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl1.Location = new System.Drawing.Point(0, 32);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(590, 343);
            this.gridControl1.TabIndex = 2;
            // 
            // persistentRepository1
            // 
            this.persistentRepository1.Items.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
                                                                                                                 this.repositoryItemTextEdit1});
            // 
            // repositoryItemTextEdit1
            // 
            this.repositoryItemTextEdit1.Name = "repositoryItemTextEdit1";
            this.repositoryItemTextEdit1.AllowFocused = false;
            this.repositoryItemTextEdit1.AutoHeight = false;
            this.repositoryItemTextEdit1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            // 
            // gridView1
            // 
            this.gridView1.DefaultEdit = this.repositoryItemTextEdit1;
            this.gridView1.Name = "gridView1";
            // 
            // btnFind
            // 
            this.btnFind.Location = new System.Drawing.Point(168, 5);
            this.btnFind.Name = "btnFind";
            this.btnFind.Size = new System.Drawing.Size(192, 23);
            this.btnFind.TabIndex = 5;
            this.btnFind.Text = "Find, focus and show editor";
            this.btnFind.Click += new System.EventHandler(this.btnFind_Click);
            // 
            // Form1
            // 
            this.AutoScale = false;
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(590, 375);
            this.Controls.AddRange(new System.Windows.Forms.Control[] {
                                                                          this.gridControl1,
                                                                          this.panel1});
            this.Name = "Form1";
            this.Text = "Grid SearchRowCellValue (C# code)";
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            this.ResumeLayout(false);

        }
		#endregion
        
		protected override void OnCreateControl() {
			base.OnCreateControl();
			FillGridWithData();
		}

		private void FillGridWithData() {
            Cursor currentCursor = Cursor.Current;
            Cursor.Current = Cursors.WaitCursor;
			DataSet dataSet1 = new DataSet();	
			String con = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + DBFileName;
		    OleDbDataAdapter work1 = new OleDbDataAdapter("SELECT * FROM Customers", con);
		    work1.Fill(dataSet1, "Customers");
            DataViewManager dvManager1 = new DataViewManager(dataSet1);
            DataView dView1 = dvManager1.CreateDataView(dataSet1.Tables["Customers"]);

            gridControl1.DataSource = dView1;
            gridControl1.MainView.PopulateColumns();

            Cursor.Current = currentCursor;
		}

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
		[STAThread]
        public static void Main(string[] args) 
        {
            Application.Run(new Form1());
        }
		#region Finding File Path
		public static string FindingFileName(string path, string name) {
			string s="\\";
			for(int i=0 ; i <= 10 ; i++) {
				if(System.IO.File.Exists(path + s + name)) {
					return (path + s + name);
				} 
				else {
					s += "..\\";
				}
			} 
			MessageBox.Show("File " + name + " is not found", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); 
			return ("");
		}
		#endregion

		private int GetRowHandleByColumnValue(GridView view, string ColumnFieldName, object value){
            int result = GridControl.InvalidRowHandle;
			for(int i = 0; i < view.RowCount; i++)
                if (view.GetDataRow(i)[ColumnFieldName].Equals(value))
                    return i;
            return result;
		}

        private void btnFind_Click(object sender, System.EventArgs e) {
            int rowHandle = GetRowHandleByColumnValue(gridView1, "CustomerID", "DRACD");
            if (rowHandle != GridControl.InvalidRowHandle){
                gridView1.FocusedColumn = gridView1.Columns.ColumnByFieldName("CustomerID");
                gridView1.FocusedRowHandle = rowHandle;
                if (gridView1.IsRowVisible(rowHandle) == RowVisibleState.Hidden)
                    gridView1.MakeRowVisible(rowHandle, false);
                gridView1.ShowEditor();
            }
            else
                MessageBox.Show("Not found!");
        }
    }
}
