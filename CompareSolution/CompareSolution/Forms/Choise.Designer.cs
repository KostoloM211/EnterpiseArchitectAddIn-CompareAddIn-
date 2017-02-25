namespace CompareSolution.Forms
{
    partial class Choise
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
            this.commonLayout = new System.Windows.Forms.TableLayoutPanel();
            this.buttonLayout = new System.Windows.Forms.TableLayoutPanel();
            this.cancelButton = new System.Windows.Forms.Button();
            this.okButton = new System.Windows.Forms.Button();
            this.topLabel = new System.Windows.Forms.Label();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.rightTreeView = new System.Windows.Forms.TreeView();
            this.leftTreeView = new System.Windows.Forms.TreeView();
            this.model1 = new System.Windows.Forms.Label();
            this.model2 = new System.Windows.Forms.Label();
            this.commonLayout.SuspendLayout();
            this.buttonLayout.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // commonLayout
            // 
            this.commonLayout.AutoSize = true;
            this.commonLayout.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.commonLayout.ColumnCount = 1;
            this.commonLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.commonLayout.Controls.Add(this.buttonLayout, 0, 2);
            this.commonLayout.Controls.Add(this.topLabel, 0, 0);
            this.commonLayout.Controls.Add(this.tableLayoutPanel1, 0, 1);
            this.commonLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.commonLayout.Location = new System.Drawing.Point(0, 0);
            this.commonLayout.Name = "commonLayout";
            this.commonLayout.RowCount = 3;
            this.commonLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 70F));
            this.commonLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.commonLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.commonLayout.Size = new System.Drawing.Size(580, 457);
            this.commonLayout.TabIndex = 0;
            // 
            // buttonLayout
            // 
            this.buttonLayout.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonLayout.ColumnCount = 2;
            this.buttonLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.95541F));
            this.buttonLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 49.04459F));
            this.buttonLayout.Controls.Add(this.cancelButton, 1, 0);
            this.buttonLayout.Controls.Add(this.okButton, 0, 0);
            this.buttonLayout.Location = new System.Drawing.Point(420, 410);
            this.buttonLayout.Name = "buttonLayout";
            this.buttonLayout.RowCount = 1;
            this.buttonLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.buttonLayout.Size = new System.Drawing.Size(157, 44);
            this.buttonLayout.TabIndex = 0;
            // 
            // cancelButton
            // 
            this.cancelButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cancelButton.Location = new System.Drawing.Point(82, 3);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(72, 38);
            this.cancelButton.TabIndex = 0;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButtonClicked);
            // 
            // okButton
            // 
            this.okButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.okButton.Location = new System.Drawing.Point(3, 3);
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size(73, 38);
            this.okButton.TabIndex = 1;
            this.okButton.Text = "OK";
            this.okButton.UseVisualStyleBackColor = true;
            this.okButton.Click += new System.EventHandler(this.okButtonClicked);
            // 
            // topLabel
            // 
            this.topLabel.AutoSize = true;
            this.topLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.topLabel.Location = new System.Drawing.Point(3, 0);
            this.topLabel.Name = "topLabel";
            this.topLabel.Size = new System.Drawing.Size(574, 70);
            this.topLabel.TabIndex = 1;
            this.topLabel.Text = "Выберете модели для сравнения:";
            this.topLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.rightTreeView, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.leftTreeView, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.model1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.model2, 1, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 73);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(574, 331);
            this.tableLayoutPanel1.TabIndex = 2;
            // 
            // rightTreeView
            // 
            this.rightTreeView.AllowDrop = true;
            this.rightTreeView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rightTreeView.Location = new System.Drawing.Point(290, 33);
            this.rightTreeView.Name = "rightTreeView";
            this.rightTreeView.Size = new System.Drawing.Size(281, 295);
            this.rightTreeView.TabIndex = 0;
            this.rightTreeView.ItemDrag += new System.Windows.Forms.ItemDragEventHandler(this.rightTreeView_ItemDrag);
            this.rightTreeView.DragEnter += new System.Windows.Forms.DragEventHandler(this.rightTreeView_DragEnter);
            this.rightTreeView.DragDrop += new System.Windows.Forms.DragEventHandler(this.rightTreeView_DragDrop);
            // 
            // leftTreeView
            // 
            this.leftTreeView.AllowDrop = true;
            this.leftTreeView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.leftTreeView.Location = new System.Drawing.Point(3, 33);
            this.leftTreeView.Name = "leftTreeView";
            this.leftTreeView.Size = new System.Drawing.Size(281, 295);
            this.leftTreeView.TabIndex = 1;
            this.leftTreeView.ItemDrag += new System.Windows.Forms.ItemDragEventHandler(this.leftTreeView_ItemDrag);
            this.leftTreeView.DragEnter += new System.Windows.Forms.DragEventHandler(this.leftTreeView_DragEnter);
            this.leftTreeView.DragDrop += new System.Windows.Forms.DragEventHandler(this.leftTreeView_DragDrop);

            // 
            // model1
            // 
            this.model1.AutoSize = true;
            this.model1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.model1.Location = new System.Drawing.Point(3, 0);
            this.model1.Name = "model1";
            this.model1.Size = new System.Drawing.Size(281, 30);
            this.model1.TabIndex = 2;
            this.model1.Text = "Модель 1";
            this.model1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // model2
            // 
            this.model2.AutoSize = true;
            this.model2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.model2.Location = new System.Drawing.Point(290, 0);
            this.model2.Name = "model2";
            this.model2.Size = new System.Drawing.Size(281, 30);
            this.model2.TabIndex = 3;
            this.model2.Text = "Модель 2";
            this.model2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Choise
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(580, 457);
            this.Controls.Add(this.commonLayout);
            this.Name = "Choise";
            this.Text = "Choise";
            this.commonLayout.ResumeLayout(false);
            this.commonLayout.PerformLayout();
            this.buttonLayout.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel commonLayout;
        private System.Windows.Forms.TableLayoutPanel buttonLayout;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Button okButton;
        private System.Windows.Forms.Label topLabel;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TreeView rightTreeView;
        private System.Windows.Forms.TreeView leftTreeView;
        private System.Windows.Forms.Label model1;
        private System.Windows.Forms.Label model2;


    }
}