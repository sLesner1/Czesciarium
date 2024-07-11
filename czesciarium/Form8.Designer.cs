using System.Windows.Forms;

namespace czesciarium
{
    partial class Form8
    {
        /// <summary>
        /// Wymagana zmienna projektanta.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Wyczyść wszystkie używane zasoby.
        /// </summary>
        /// <param name="disposing">prawda, jeżeli zarządzane zasoby powinny zostać zlikwidowane; Fałsz w przeciwnym wypadku.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Kod generowany przez Projektanta formularzy systemu Windows

        /// <summary>
        /// Metoda wymagana do obsługi projektanta — nie należy modyfikować
        /// jej zawartości w edytorze kodu.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label1 = new System.Windows.Forms.Label();
            this.czesciBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.pracownicyDataSet = new czesciarium.pracownicyDataSet();
            this.czesciTableAdapter = new czesciarium.pracownicyDataSetTableAdapters.CzesciTableAdapter();
            this.tableAdapterManager = new czesciarium.pracownicyDataSetTableAdapters.TableAdapterManager();
            this.czesciTableAdapter1 = new czesciarium.pracownicyDataSetTableAdapters.CzesciTableAdapter();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.button7 = new System.Windows.Forms.Button();
            this.pracownicyTabBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.pracownicyDataSet1BindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.pracownicyDataSet1 = new czesciarium.pracownicyDataSet();
            this.operacjeBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.operacjeTableAdapter = new czesciarium.pracownicyDataSetTableAdapters.OperacjeTableAdapter();
            this.operacjeDataGridView = new System.Windows.Forms.DataGridView();
            this.pracownicyTabTableAdapter = new czesciarium.pracownicyDataSetTableAdapters.pracownicyTabTableAdapter();
            this.pracownicyTabBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.pracownicyTabBindingSource2 = new System.Windows.Forms.BindingSource(this.components);
            this.pracownicyTabComboBox1 = new System.Windows.Forms.ComboBox();
            this.idOperacjiDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idPracownikaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.opisOperacjiDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataWykonaniaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.czesciBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pracownicyDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pracownicyTabBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pracownicyDataSet1BindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pracownicyDataSet1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.operacjeBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.operacjeDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pracownicyTabBindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pracownicyTabBindingSource2)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Tahoma", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(78)))), ((int)(((byte)(71)))));
            this.label1.Location = new System.Drawing.Point(4, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(863, 48);
            this.label1.TabIndex = 5;
            this.label1.Text = "Ostatnie operacje";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // czesciBindingSource
            // 
            this.czesciBindingSource.DataMember = "Czesci";
            this.czesciBindingSource.DataSource = this.pracownicyDataSet;
            // 
            // pracownicyDataSet
            // 
            this.pracownicyDataSet.DataSetName = "pracownicyDataSet";
            this.pracownicyDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // czesciTableAdapter
            // 
            this.czesciTableAdapter.ClearBeforeFill = true;
            // 
            // tableAdapterManager
            // 
            this.tableAdapterManager.AdministratorTableAdapter = null;
            this.tableAdapterManager.BackupDataSetBeforeUpdate = false;
            this.tableAdapterManager.CzesciTableAdapter = this.czesciTableAdapter;
            this.tableAdapterManager.OperacjeTableAdapter = null;
            this.tableAdapterManager.pracownicyTabTableAdapter = null;
            this.tableAdapterManager.UpdateOrder = czesciarium.pracownicyDataSetTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete;
            // 
            // czesciTableAdapter1
            // 
            this.czesciTableAdapter1.ClearBeforeFill = true;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::czesciarium.Properties.Resources.logo1;
            this.pictureBox1.Location = new System.Drawing.Point(12, 11);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(200, 48);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 21;
            this.pictureBox1.TabStop = false;
            // 
            // button7
            // 
            this.button7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(230)))), ((int)(((byte)(179)))));
            this.button7.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button7.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(86)))), ((int)(((byte)(130)))), ((int)(((byte)(89)))));
            this.button7.FlatAppearance.BorderSize = 3;
            this.button7.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button7.Font = new System.Drawing.Font("Tahoma", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.button7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(78)))), ((int)(((byte)(71)))));
            this.button7.Location = new System.Drawing.Point(313, 464);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(233, 95);
            this.button7.TabIndex = 19;
            this.button7.Text = "Potwierdź";
            this.button7.UseVisualStyleBackColor = false;
            this.button7.Click += new System.EventHandler(this.button7_Click);
            // 
            // pracownicyTabBindingSource
            // 
            this.pracownicyTabBindingSource.DataMember = "pracownicyTab";
            this.pracownicyTabBindingSource.DataSource = this.pracownicyDataSet1BindingSource;
            // 
            // pracownicyDataSet1BindingSource
            // 
            this.pracownicyDataSet1BindingSource.DataSource = this.pracownicyDataSet1;
            this.pracownicyDataSet1BindingSource.Position = 0;
            // 
            // pracownicyDataSet1
            // 
            this.pracownicyDataSet1.DataSetName = "pracownicyDataSet";
            this.pracownicyDataSet1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // operacjeBindingSource
            // 
            this.operacjeBindingSource.DataMember = "Operacje";
            this.operacjeBindingSource.DataSource = this.pracownicyDataSet;
            // 
            // operacjeTableAdapter
            // 
            this.operacjeTableAdapter.ClearBeforeFill = true;
            // 
            // operacjeDataGridView
            // 
            this.operacjeDataGridView.AllowUserToAddRows = false;
            this.operacjeDataGridView.AllowUserToDeleteRows = false;
            this.operacjeDataGridView.AutoGenerateColumns = false;
            this.operacjeDataGridView.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(252)))), ((int)(((byte)(203)))));
            this.operacjeDataGridView.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.operacjeDataGridView.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(230)))), ((int)(((byte)(179)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Tahoma", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(78)))), ((int)(((byte)(71)))));
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.operacjeDataGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.operacjeDataGridView.ColumnHeadersHeight = 36;
            this.operacjeDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idOperacjiDataGridViewTextBoxColumn,
            this.idPracownikaDataGridViewTextBoxColumn,
            this.opisOperacjiDataGridViewTextBoxColumn,
            this.dataWykonaniaDataGridViewTextBoxColumn});
            this.operacjeDataGridView.DataSource = this.operacjeBindingSource;
            this.operacjeDataGridView.EnableHeadersVisualStyles = false;
            this.operacjeDataGridView.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(86)))), ((int)(((byte)(130)))), ((int)(((byte)(89)))));
            this.operacjeDataGridView.Location = new System.Drawing.Point(12, 128);
            this.operacjeDataGridView.Name = "operacjeDataGridView";
            this.operacjeDataGridView.ReadOnly = true;
            this.operacjeDataGridView.RowHeadersVisible = false;
            this.operacjeDataGridView.RowHeadersWidth = 51;
            this.operacjeDataGridView.RowTemplate.DefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(255)))), ((int)(((byte)(245)))));
            this.operacjeDataGridView.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Tahoma", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.operacjeDataGridView.RowTemplate.DefaultCellStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(78)))), ((int)(((byte)(71)))));
            this.operacjeDataGridView.RowTemplate.Height = 24;
            this.operacjeDataGridView.Size = new System.Drawing.Size(843, 309);
            this.operacjeDataGridView.TabIndex = 58;
            this.operacjeDataGridView.TabStop = false;
            this.operacjeDataGridView.Paint += new System.Windows.Forms.PaintEventHandler(this.operacjeDataGridView_Paint);
            // 
            // pracownicyTabTableAdapter
            // 
            this.pracownicyTabTableAdapter.ClearBeforeFill = true;
            // 
            // pracownicyTabBindingSource1
            // 
            this.pracownicyTabBindingSource1.DataMember = "pracownicyTab";
            this.pracownicyTabBindingSource1.DataSource = this.pracownicyDataSet;
            // 
            // pracownicyTabBindingSource2
            // 
            this.pracownicyTabBindingSource2.DataMember = "pracownicyTab";
            this.pracownicyTabBindingSource2.DataSource = this.pracownicyDataSet1;
            // 
            // pracownicyTabComboBox1
            // 
            this.pracownicyTabComboBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(255)))), ((int)(((byte)(245)))));
            this.pracownicyTabComboBox1.DataSource = this.pracownicyTabBindingSource2;
            this.pracownicyTabComboBox1.DisplayMember = "Login";
            this.pracownicyTabComboBox1.Font = new System.Drawing.Font("Tahoma", 14F, System.Drawing.FontStyle.Bold);
            this.pracownicyTabComboBox1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(78)))), ((int)(((byte)(71)))));
            this.pracownicyTabComboBox1.FormattingEnabled = true;
            this.pracownicyTabComboBox1.Location = new System.Drawing.Point(12, 86);
            this.pracownicyTabComboBox1.Name = "pracownicyTabComboBox1";
            this.pracownicyTabComboBox1.Size = new System.Drawing.Size(845, 36);
            this.pracownicyTabComboBox1.TabIndex = 58;
            this.pracownicyTabComboBox1.ValueMember = "Id";
            this.pracownicyTabComboBox1.SelectedIndexChanged += new System.EventHandler(this.pracownicyTabComboBox1_SelectedIndexChanged);
            // 
            // idOperacjiDataGridViewTextBoxColumn
            // 
            this.idOperacjiDataGridViewTextBoxColumn.DataPropertyName = "IdOperacji";
            this.idOperacjiDataGridViewTextBoxColumn.HeaderText = "IdOperacji";
            this.idOperacjiDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.idOperacjiDataGridViewTextBoxColumn.Name = "idOperacjiDataGridViewTextBoxColumn";
            this.idOperacjiDataGridViewTextBoxColumn.ReadOnly = true;
            this.idOperacjiDataGridViewTextBoxColumn.Width = 125;
            // 
            // idPracownikaDataGridViewTextBoxColumn
            // 
            this.idPracownikaDataGridViewTextBoxColumn.DataPropertyName = "IdPracownika";
            this.idPracownikaDataGridViewTextBoxColumn.HeaderText = "IdPracownika";
            this.idPracownikaDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.idPracownikaDataGridViewTextBoxColumn.Name = "idPracownikaDataGridViewTextBoxColumn";
            this.idPracownikaDataGridViewTextBoxColumn.ReadOnly = true;
            this.idPracownikaDataGridViewTextBoxColumn.Width = 125;
            // 
            // opisOperacjiDataGridViewTextBoxColumn
            // 
            this.opisOperacjiDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.opisOperacjiDataGridViewTextBoxColumn.DataPropertyName = "OpisOperacji";
            this.opisOperacjiDataGridViewTextBoxColumn.HeaderText = "OpisOperacji";
            this.opisOperacjiDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.opisOperacjiDataGridViewTextBoxColumn.Name = "opisOperacjiDataGridViewTextBoxColumn";
            this.opisOperacjiDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // dataWykonaniaDataGridViewTextBoxColumn
            // 
            this.dataWykonaniaDataGridViewTextBoxColumn.DataPropertyName = "DataWykonania";
            this.dataWykonaniaDataGridViewTextBoxColumn.HeaderText = "DataWykonania";
            this.dataWykonaniaDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.dataWykonaniaDataGridViewTextBoxColumn.Name = "dataWykonaniaDataGridViewTextBoxColumn";
            this.dataWykonaniaDataGridViewTextBoxColumn.ReadOnly = true;
            this.dataWykonaniaDataGridViewTextBoxColumn.Width = 125;
            // 
            // Form8
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(252)))), ((int)(((byte)(203)))));
            this.ClientSize = new System.Drawing.Size(869, 579);
            this.Controls.Add(this.pracownicyTabComboBox1);
            this.Controls.Add(this.operacjeDataGridView);
            this.Controls.Add(this.button7);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Form8";
            this.Text = "Zarządzaj - Częściarium";
            this.Load += new System.EventHandler(this.Form8_Load);
            ((System.ComponentModel.ISupportInitialize)(this.czesciBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pracownicyDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pracownicyTabBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pracownicyDataSet1BindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pracownicyDataSet1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.operacjeBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.operacjeDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pracownicyTabBindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pracownicyTabBindingSource2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private pracownicyDataSet pracownicyDataSet;
        private System.Windows.Forms.BindingSource czesciBindingSource;
        private pracownicyDataSetTableAdapters.CzesciTableAdapter czesciTableAdapter;
        private pracownicyDataSetTableAdapters.TableAdapterManager tableAdapterManager;
        private pracownicyDataSetTableAdapters.CzesciTableAdapter czesciTableAdapter1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.BindingSource operacjeBindingSource;
        private pracownicyDataSetTableAdapters.OperacjeTableAdapter operacjeTableAdapter;
        private System.Windows.Forms.DataGridView operacjeDataGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private BindingSource pracownicyDataSet1BindingSource;
        private pracownicyDataSet pracownicyDataSet1;
        private BindingSource pracownicyTabBindingSource;
        private pracownicyDataSetTableAdapters.pracownicyTabTableAdapter pracownicyTabTableAdapter;
        private BindingSource pracownicyTabBindingSource1;
        private BindingSource pracownicyTabBindingSource2;
        private ComboBox pracownicyTabComboBox1;
        private DataGridViewTextBoxColumn idOperacjiDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn idPracownikaDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn opisOperacjiDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn dataWykonaniaDataGridViewTextBoxColumn;
    }
}

