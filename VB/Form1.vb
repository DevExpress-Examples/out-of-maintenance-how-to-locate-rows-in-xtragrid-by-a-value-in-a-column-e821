Imports Microsoft.VisualBasic
	Imports System
	Imports System.Drawing
	Imports System.Collections
	Imports System.ComponentModel
	Imports System.Windows.Forms
	Imports System.Data
	Imports System.Data.OleDb
	Imports System.Reflection
	Imports DevExpress.Utils
	Imports DevExpress.XtraGrid
	Imports DevExpress.XtraGrid.Views.Grid
	Imports DevExpress.XtraGrid.Views.Grid.ViewInfo
	Imports DevExpress.XtraGrid.Drawing
	Imports DevExpress.XtraGrid.Columns
Namespace DevExpress.XtraGrid.Demos.Tutorial.GridPopulation

	''' <summary>
	'''    Summary description for Form1.
	''' </summary>
	Public Class Form1
		Inherits System.Windows.Forms.Form
		Private panel1 As System.Windows.Forms.Panel
		Private label1 As System.Windows.Forms.Label
		Private label2 As System.Windows.Forms.Label
		Private gridControl1 As DevExpress.XtraGrid.GridControl
		Private persistentRepository1 As DevExpress.XtraEditors.Repository.PersistentRepository
		Private gridView1 As DevExpress.XtraGrid.Views.Grid.GridView
		Private repositoryItemTextEdit1 As DevExpress.XtraEditors.Repository.RepositoryItemTextEdit
		Private WithEvents btnFind As System.Windows.Forms.Button
		Private DBFileName As String

		Public Sub New()
			'
			' Required for Windows Form Designer support
			'
			DBFileName = FindingFileName(Application.StartupPath,"Data\nwind.mdb")
			InitializeComponent()
			'
			' TODO: Add any constructor code after InitializeComponent call
			'
		End Sub

		#Region "Windows Form Designer generated code"
		Private Sub InitializeComponent()
			Dim resources As New System.Resources.ResourceManager(GetType(Form1))
			Me.panel1 = New System.Windows.Forms.Panel()
			Me.label1 = New System.Windows.Forms.Label()
			Me.label2 = New System.Windows.Forms.Label()
			Me.gridControl1 = New DevExpress.XtraGrid.GridControl()
			Me.persistentRepository1 = New DevExpress.XtraEditors.Repository.PersistentRepository()
			Me.repositoryItemTextEdit1 = New DevExpress.XtraEditors.Repository.RepositoryItemTextEdit()
			Me.gridView1 = New DevExpress.XtraGrid.Views.Grid.GridView()
			Me.btnFind = New System.Windows.Forms.Button()
			Me.panel1.SuspendLayout()
			CType(Me.gridControl1, System.ComponentModel.ISupportInitialize).BeginInit()
			CType(Me.repositoryItemTextEdit1, System.ComponentModel.ISupportInitialize).BeginInit()
			CType(Me.gridView1, System.ComponentModel.ISupportInitialize).BeginInit()
			Me.SuspendLayout()
			' 
			' panel1
			' 
			Me.panel1.Controls.AddRange(New System.Windows.Forms.Control() { Me.btnFind, Me.label1, Me.label2})
			Me.panel1.Dock = System.Windows.Forms.DockStyle.Top
			Me.panel1.Name = "panel1"
			Me.panel1.Size = New System.Drawing.Size(590, 32)
			Me.panel1.TabIndex = 1
			' 
			' label1
			' 
			Me.label1.Dock = System.Windows.Forms.DockStyle.Fill
			Me.label1.Location = New System.Drawing.Point(20, 0)
			Me.label1.Name = "label1"
			Me.label1.Size = New System.Drawing.Size(570, 32)
			Me.label1.TabIndex = 0
			' 
			' label2
			' 
			Me.label2.Dock = System.Windows.Forms.DockStyle.Left
			Me.label2.Image = (CType(resources.GetObject("label2.Image"), System.Drawing.Bitmap))
			Me.label2.ImageAlign = System.Drawing.ContentAlignment.TopCenter
			Me.label2.Name = "label2"
			Me.label2.Size = New System.Drawing.Size(20, 32)
			Me.label2.TabIndex = 1
			' 
			' gridControl1
			' 
			Me.gridControl1.Dock = System.Windows.Forms.DockStyle.Fill
			Me.gridControl1.Location = New System.Drawing.Point(0, 32)
			Me.gridControl1.MainView = Me.gridView1
			Me.gridControl1.Name = "gridControl1"
			Me.gridControl1.Size = New System.Drawing.Size(590, 343)
			Me.gridControl1.TabIndex = 2
			' 
			' persistentRepository1
			' 
			Me.persistentRepository1.Items.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() { Me.repositoryItemTextEdit1})
			' 
			' repositoryItemTextEdit1
			' 
			Me.repositoryItemTextEdit1.Name = "repositoryItemTextEdit1"
			Me.repositoryItemTextEdit1.AllowFocused = False
			Me.repositoryItemTextEdit1.AutoHeight = False
			Me.repositoryItemTextEdit1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
			' 
			' gridView1
			' 
			Me.gridView1.DefaultEdit = Me.repositoryItemTextEdit1
			Me.gridView1.Name = "gridView1"
			' 
			' btnFind
			' 
			Me.btnFind.Location = New System.Drawing.Point(168, 5)
			Me.btnFind.Name = "btnFind"
			Me.btnFind.Size = New System.Drawing.Size(192, 23)
			Me.btnFind.TabIndex = 5
			Me.btnFind.Text = "Find, focus and show editor"
'			Me.btnFind.Click += New System.EventHandler(Me.btnFind_Click);
			' 
			' Form1
			' 
			Me.AutoScale = False
			Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
			Me.ClientSize = New System.Drawing.Size(590, 375)
			Me.Controls.AddRange(New System.Windows.Forms.Control() { Me.gridControl1, Me.panel1})
			Me.Name = "Form1"
			Me.Text = "Grid SearchRowCellValue (C# code)"
			Me.panel1.ResumeLayout(False)
			CType(Me.gridControl1, System.ComponentModel.ISupportInitialize).EndInit()
			CType(Me.repositoryItemTextEdit1, System.ComponentModel.ISupportInitialize).EndInit()
			CType(Me.gridView1, System.ComponentModel.ISupportInitialize).EndInit()
			Me.ResumeLayout(False)

		End Sub
		#End Region

		Protected Overrides Sub OnCreateControl()
			MyBase.OnCreateControl()
			FillGridWithData()
		End Sub

		Private Sub FillGridWithData()
			Dim currentCursor As Cursor = Cursor.Current
			Cursor.Current = Cursors.WaitCursor
			Dim dataSet1 As New DataSet()
			Dim con As String = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" & DBFileName
			Dim work1 As New OleDbDataAdapter("SELECT * FROM Customers", con)
			work1.Fill(dataSet1, "Customers")
			Dim dvManager1 As New DataViewManager(dataSet1)
			Dim dView1 As DataView = dvManager1.CreateDataView(dataSet1.Tables("Customers"))

			gridControl1.DataSource = dView1
			gridControl1.MainView.PopulateColumns()

			Cursor.Current = currentCursor
		End Sub

		''' <summary>
		''' The main entry point for the application.
		''' </summary>
		<STAThread> _
		Public Shared Sub Main(ByVal args() As String)
			Application.Run(New Form1())
		End Sub
		#Region "Finding File Path"
		Public Shared Function FindingFileName(ByVal path As String, ByVal name As String) As String
			Dim s As String="\"
			For i As Integer = 0 To 10
				If System.IO.File.Exists(path & s & name) Then
					Return (path & s & name)
				Else
					s &= "..\"
				End If
			Next i
			MessageBox.Show("File " & name & " is not found", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
			Return ("")
		End Function
		#End Region

		Private Function GetRowHandleByColumnValue(ByVal view As GridView, ByVal ColumnFieldName As String, ByVal value As Object) As Integer
			Dim result As Integer = GridControl.InvalidRowHandle
			For i As Integer = 0 To view.RowCount - 1
				If view.GetDataRow(i)(ColumnFieldName).Equals(value) Then
					Return i
				End If
			Next i
			Return result
		End Function

		Private Sub btnFind_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnFind.Click
			Dim rowHandle As Integer = GetRowHandleByColumnValue(gridView1, "CustomerID", "DRACD")
			If rowHandle <> GridControl.InvalidRowHandle Then
				gridView1.FocusedColumn = gridView1.Columns.ColumnByFieldName("CustomerID")
				gridView1.FocusedRowHandle = rowHandle
				If gridView1.IsRowVisible(rowHandle) = RowVisibleState.Hidden Then
					gridView1.MakeRowVisible(rowHandle, False)
				End If
				gridView1.ShowEditor()
			Else
				MessageBox.Show("Not found!")
			End If
		End Sub
	End Class
End Namespace
