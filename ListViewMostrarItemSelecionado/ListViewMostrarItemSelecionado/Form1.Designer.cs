namespace ListViewMostrarItemSelecionado
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.Lista = new System.Windows.Forms.ListView();
            this.SelecionarUltimoItem = new System.Windows.Forms.Button();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SuspendLayout();
            // 
            // Lista
            // 
            this.Lista.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1});
            this.Lista.Location = new System.Drawing.Point(12, 12);
            this.Lista.Name = "Lista";
            this.Lista.Size = new System.Drawing.Size(297, 240);
            this.Lista.TabIndex = 0;
            this.Lista.UseCompatibleStateImageBehavior = false;
            this.Lista.View = System.Windows.Forms.View.Details;
            // 
            // SelecionarUltimoItem
            // 
            this.SelecionarUltimoItem.Location = new System.Drawing.Point(12, 262);
            this.SelecionarUltimoItem.Name = "SelecionarUltimoItem";
            this.SelecionarUltimoItem.Size = new System.Drawing.Size(297, 46);
            this.SelecionarUltimoItem.TabIndex = 1;
            this.SelecionarUltimoItem.Text = "Selecionar Último Item";
            this.SelecionarUltimoItem.UseVisualStyleBackColor = true;
            this.SelecionarUltimoItem.Click += new System.EventHandler(this.SelecionarUltimoItem_Click);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Item";
            this.columnHeader1.Width = 200;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(321, 319);
            this.Controls.Add(this.SelecionarUltimoItem);
            this.Controls.Add(this.Lista);
            this.Name = "Form1";
            this.Text = "ListView - Mostrar Item Selecionado";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView Lista;
        private System.Windows.Forms.Button SelecionarUltimoItem;
        private System.Windows.Forms.ColumnHeader columnHeader1;
    }
}

