
namespace PanelManagement
{
    partial class FrmPanelViewer
    {
        /// <summary>
        /// Variável de designer necessária.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpar os recursos que estão sendo usados.
        /// </summary>
        /// <param name="disposing">true se for necessário descartar os recursos gerenciados; caso contrário, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código gerado pelo Windows Form Designer

        /// <summary>
        /// Método necessário para suporte ao Designer - não modifique 
        /// o conteúdo deste método com o editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            this.GrpCentrals = new System.Windows.Forms.GroupBox();
            this.DgvCentrals = new System.Windows.Forms.DataGridView();
            this.DgvCentralsColCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GrpEvents = new System.Windows.Forms.GroupBox();
            this.DgvEvents = new System.Windows.Forms.DataGridView();
            this.DgvEventsColDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DgvEventsColCentralCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DgvEventsColAcc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DgvEventsColCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DgvEventsColDesc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DgvEventsColPart = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DgvEventsColZone = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DgvEventsColUser = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GrpCentrals.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DgvCentrals)).BeginInit();
            this.GrpEvents.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DgvEvents)).BeginInit();
            this.SuspendLayout();
            // 
            // GrpCentrals
            // 
            this.GrpCentrals.Controls.Add(this.DgvCentrals);
            this.GrpCentrals.Location = new System.Drawing.Point(12, 12);
            this.GrpCentrals.Name = "GrpCentrals";
            this.GrpCentrals.Size = new System.Drawing.Size(100, 450);
            this.GrpCentrals.TabIndex = 0;
            this.GrpCentrals.TabStop = false;
            this.GrpCentrals.Text = "Centrais";
            // 
            // DgvCentrals
            // 
            this.DgvCentrals.AllowUserToAddRows = false;
            this.DgvCentrals.AllowUserToDeleteRows = false;
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DgvCentrals.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle7;
            this.DgvCentrals.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DgvCentrals.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.DgvCentralsColCode});
            this.DgvCentrals.Location = new System.Drawing.Point(12, 18);
            this.DgvCentrals.Name = "DgvCentrals";
            this.DgvCentrals.ReadOnly = true;
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle9.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle9.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle9.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle9.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DgvCentrals.RowHeadersDefaultCellStyle = dataGridViewCellStyle9;
            this.DgvCentrals.RowHeadersVisible = false;
            this.DgvCentrals.Size = new System.Drawing.Size(78, 416);
            this.DgvCentrals.TabIndex = 0;
            // 
            // DgvCentralsColCode
            // 
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.DgvCentralsColCode.DefaultCellStyle = dataGridViewCellStyle8;
            this.DgvCentralsColCode.HeaderText = "Códigos";
            this.DgvCentralsColCode.Name = "DgvCentralsColCode";
            this.DgvCentralsColCode.ReadOnly = true;
            this.DgvCentralsColCode.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.DgvCentralsColCode.Width = 75;
            // 
            // GrpEvents
            // 
            this.GrpEvents.Controls.Add(this.DgvEvents);
            this.GrpEvents.Location = new System.Drawing.Point(120, 12);
            this.GrpEvents.Name = "GrpEvents";
            this.GrpEvents.Size = new System.Drawing.Size(842, 450);
            this.GrpEvents.TabIndex = 1;
            this.GrpEvents.TabStop = false;
            this.GrpEvents.Text = "Eventos";
            // 
            // DgvEvents
            // 
            this.DgvEvents.AllowUserToAddRows = false;
            this.DgvEvents.AllowUserToDeleteRows = false;
            this.DgvEvents.AllowUserToResizeColumns = false;
            this.DgvEvents.AllowUserToResizeRows = false;
            this.DgvEvents.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DgvEvents.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.DgvEventsColDate,
            this.DgvEventsColCentralCode,
            this.DgvEventsColAcc,
            this.DgvEventsColCode,
            this.DgvEventsColDesc,
            this.DgvEventsColPart,
            this.DgvEventsColZone,
            this.DgvEventsColUser});
            this.DgvEvents.Location = new System.Drawing.Point(12, 18);
            this.DgvEvents.Name = "DgvEvents";
            this.DgvEvents.ReadOnly = true;
            this.DgvEvents.RowHeadersVisible = false;
            this.DgvEvents.Size = new System.Drawing.Size(819, 416);
            this.DgvEvents.TabIndex = 2;
            // 
            // DgvEventsColDate
            // 
            this.DgvEventsColDate.HeaderText = "Data";
            this.DgvEventsColDate.Name = "DgvEventsColDate";
            this.DgvEventsColDate.ReadOnly = true;
            // 
            // DgvEventsColCentralCode
            // 
            this.DgvEventsColCentralCode.HeaderText = "Central";
            this.DgvEventsColCentralCode.Name = "DgvEventsColCentralCode";
            this.DgvEventsColCentralCode.ReadOnly = true;
            this.DgvEventsColCentralCode.Width = 75;
            // 
            // DgvEventsColAcc
            // 
            this.DgvEventsColAcc.HeaderText = "Conta";
            this.DgvEventsColAcc.Name = "DgvEventsColAcc";
            this.DgvEventsColAcc.ReadOnly = true;
            this.DgvEventsColAcc.Width = 75;
            // 
            // DgvEventsColCode
            // 
            this.DgvEventsColCode.HeaderText = "Evento";
            this.DgvEventsColCode.Name = "DgvEventsColCode";
            this.DgvEventsColCode.ReadOnly = true;
            this.DgvEventsColCode.Width = 75;
            // 
            // DgvEventsColDesc
            // 
            this.DgvEventsColDesc.HeaderText = "Descrição";
            this.DgvEventsColDesc.Name = "DgvEventsColDesc";
            this.DgvEventsColDesc.ReadOnly = true;
            this.DgvEventsColDesc.Width = 250;
            // 
            // DgvEventsColPart
            // 
            this.DgvEventsColPart.HeaderText = "Partição";
            this.DgvEventsColPart.Name = "DgvEventsColPart";
            this.DgvEventsColPart.ReadOnly = true;
            this.DgvEventsColPart.Width = 75;
            // 
            // DgvEventsColZone
            // 
            this.DgvEventsColZone.HeaderText = "Zona";
            this.DgvEventsColZone.Name = "DgvEventsColZone";
            this.DgvEventsColZone.ReadOnly = true;
            this.DgvEventsColZone.Width = 75;
            // 
            // DgvEventsColUser
            // 
            this.DgvEventsColUser.HeaderText = "Usuário";
            this.DgvEventsColUser.Name = "DgvEventsColUser";
            this.DgvEventsColUser.ReadOnly = true;
            this.DgvEventsColUser.Width = 75;
            // 
            // FrmPanelViewer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(974, 471);
            this.Controls.Add(this.GrpEvents);
            this.Controls.Add(this.GrpCentrals);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(990, 510);
            this.MinimumSize = new System.Drawing.Size(990, 510);
            this.Name = "FrmPanelViewer";
            this.ShowIcon = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Alarmes";
            this.Shown += new System.EventHandler(this.FrmPanelViewer_Shown);
            this.GrpCentrals.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DgvCentrals)).EndInit();
            this.GrpEvents.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DgvEvents)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox GrpCentrals;
        private System.Windows.Forms.GroupBox GrpEvents;
        private System.Windows.Forms.DataGridView DgvEvents;
        private System.Windows.Forms.DataGridView DgvCentrals;
        private System.Windows.Forms.DataGridViewTextBoxColumn DgvCentralsColCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn DgvEventsColDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn DgvEventsColCentralCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn DgvEventsColAcc;
        private System.Windows.Forms.DataGridViewTextBoxColumn DgvEventsColCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn DgvEventsColDesc;
        private System.Windows.Forms.DataGridViewTextBoxColumn DgvEventsColPart;
        private System.Windows.Forms.DataGridViewTextBoxColumn DgvEventsColZone;
        private System.Windows.Forms.DataGridViewTextBoxColumn DgvEventsColUser;
    }
}

