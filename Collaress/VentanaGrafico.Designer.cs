using System;
using System.Windows.Forms.DataVisualization.Charting;

namespace Collaress
{
    partial class VentanaGrafico
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            this.graficoVacaInfo = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.lblVacaId = new System.Windows.Forms.Label();
            this.puerto = new System.IO.Ports.SerialPort(this.components);
            this.temporizador = new System.Windows.Forms.Timer(this.components);
            this.listVacas = new System.Windows.Forms.ListBox();
            this.txtBusqueda = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.tipBusqueda = new System.Windows.Forms.ToolTip(this.components);
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox6 = new System.Windows.Forms.PictureBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.pictureBox5 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.btnBusqueda = new System.Windows.Forms.Button();
            this.btnCrearWord = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.graficoVacaInfo)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // graficoVacaInfo
            // 
            this.graficoVacaInfo.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.graficoVacaInfo.BackColor = System.Drawing.Color.Transparent;
            this.graficoVacaInfo.BorderlineColor = System.Drawing.Color.Transparent;
            chartArea1.Name = "ChartArea1";
            this.graficoVacaInfo.ChartAreas.Add(chartArea1);
            legend1.Docking = System.Windows.Forms.DataVisualization.Charting.Docking.Bottom;
            legend1.Name = "Legend1";
            this.graficoVacaInfo.Legends.Add(legend1);
            this.graficoVacaInfo.Location = new System.Drawing.Point(-3, 1);
            this.graficoVacaInfo.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.graficoVacaInfo.Name = "graficoVacaInfo";
            this.graficoVacaInfo.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.Bright;
            this.graficoVacaInfo.Size = new System.Drawing.Size(559, 369);
            this.graficoVacaInfo.TabIndex = 0;
            this.graficoVacaInfo.Text = "chart1";
            // 
            // lblVacaId
            // 
            this.lblVacaId.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(153)))), ((int)(((byte)(87)))));
            this.lblVacaId.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblVacaId.Font = new System.Drawing.Font("Noto Sans", 39.75F, System.Drawing.FontStyle.Bold);
            this.lblVacaId.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.lblVacaId.Location = new System.Drawing.Point(0, 0);
            this.lblVacaId.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblVacaId.Name = "lblVacaId";
            this.lblVacaId.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lblVacaId.Size = new System.Drawing.Size(804, 82);
            this.lblVacaId.TabIndex = 1;
            this.lblVacaId.Text = "Vaca";
            this.lblVacaId.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // puerto
            // 
            this.puerto.DtrEnable = true;
            this.puerto.PortName = "COM8";
            this.puerto.RtsEnable = true;
            this.puerto.DataReceived += new System.IO.Ports.SerialDataReceivedEventHandler(this.puerto_DataReceived);
            // 
            // temporizador
            // 
            this.temporizador.Enabled = true;
            this.temporizador.Interval = 5000;
            this.temporizador.Tick += new System.EventHandler(this.temporizador_Tick);
            // 
            // listVacas
            // 
            this.listVacas.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.listVacas.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(153)))), ((int)(((byte)(87)))));
            this.listVacas.Font = new System.Drawing.Font("Noto Sans", 12F, System.Drawing.FontStyle.Bold);
            this.listVacas.ForeColor = System.Drawing.SystemColors.Window;
            this.listVacas.FormattingEnabled = true;
            this.listVacas.ItemHeight = 22;
            this.listVacas.Location = new System.Drawing.Point(28, 60);
            this.listVacas.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.listVacas.Name = "listVacas";
            this.listVacas.Size = new System.Drawing.Size(201, 290);
            this.listVacas.TabIndex = 3;
            this.listVacas.SelectedValueChanged += new System.EventHandler(this.listVacas_SelectedValueChanged);
            // 
            // txtBusqueda
            // 
            this.txtBusqueda.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(153)))), ((int)(((byte)(87)))));
            this.txtBusqueda.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtBusqueda.Font = new System.Drawing.Font("Noto Sans", 14.25F, System.Drawing.FontStyle.Bold);
            this.txtBusqueda.ForeColor = System.Drawing.SystemColors.Window;
            this.txtBusqueda.Location = new System.Drawing.Point(28, 17);
            this.txtBusqueda.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.txtBusqueda.Name = "txtBusqueda";
            this.txtBusqueda.Size = new System.Drawing.Size(162, 33);
            this.txtBusqueda.TabIndex = 4;
            this.tipBusqueda.SetToolTip(this.txtBusqueda, "Ingrese el número ID de la vaca");
            this.txtBusqueda.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtBusqueda_KeyPress);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.Controls.Add(this.btnCrearWord);
            this.panel1.Controls.Add(this.graficoVacaInfo);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(804, 369);
            this.panel1.TabIndex = 6;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Transparent;
            this.panel2.Controls.Add(this.btnBusqueda);
            this.panel2.Controls.Add(this.txtBusqueda);
            this.panel2.Controls.Add(this.listVacas);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel2.Location = new System.Drawing.Point(553, 82);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(251, 369);
            this.panel2.TabIndex = 7;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.Transparent;
            this.panel3.Controls.Add(this.panel1);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(0, 82);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(804, 369);
            this.panel3.TabIndex = 8;
            // 
            // tipBusqueda
            // 
            this.tipBusqueda.AutomaticDelay = 300;
            this.tipBusqueda.AutoPopDelay = 3000;
            this.tipBusqueda.InitialDelay = 200;
            this.tipBusqueda.ReshowDelay = 10;
            this.tipBusqueda.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.tipBusqueda.ToolTipTitle = "Buscar";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(4)))), ((int)(((byte)(96)))), ((int)(((byte)(40)))));
            this.pictureBox1.Location = new System.Drawing.Point(0, 75);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(806, 10);
            this.pictureBox1.TabIndex = 9;
            this.pictureBox1.TabStop = false;
            // 
            // pictureBox6
            // 
            this.pictureBox6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(4)))), ((int)(((byte)(96)))), ((int)(((byte)(40)))));
            this.pictureBox6.Location = new System.Drawing.Point(766, 27);
            this.pictureBox6.Name = "pictureBox6";
            this.pictureBox6.Size = new System.Drawing.Size(38, 10);
            this.pictureBox6.TabIndex = 9;
            this.pictureBox6.TabStop = false;
            // 
            // pictureBox3
            // 
            this.pictureBox3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(4)))), ((int)(((byte)(96)))), ((int)(((byte)(40)))));
            this.pictureBox3.Location = new System.Drawing.Point(0, 28);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(38, 10);
            this.pictureBox3.TabIndex = 9;
            this.pictureBox3.TabStop = false;
            // 
            // pictureBox4
            // 
            this.pictureBox4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(112)))), ((int)(((byte)(62)))));
            this.pictureBox4.Location = new System.Drawing.Point(551, 77);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(10, 374);
            this.pictureBox4.TabIndex = 9;
            this.pictureBox4.TabStop = false;
            // 
            // pictureBox5
            // 
            this.pictureBox5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(4)))), ((int)(((byte)(96)))), ((int)(((byte)(40)))));
            this.pictureBox5.Location = new System.Drawing.Point(0, 47);
            this.pictureBox5.Name = "pictureBox5";
            this.pictureBox5.Size = new System.Drawing.Size(111, 10);
            this.pictureBox5.TabIndex = 9;
            this.pictureBox5.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(4)))), ((int)(((byte)(96)))), ((int)(((byte)(40)))));
            this.pictureBox2.Location = new System.Drawing.Point(693, 8);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(111, 10);
            this.pictureBox2.TabIndex = 9;
            this.pictureBox2.TabStop = false;
            // 
            // btnBusqueda
            // 
            this.btnBusqueda.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(153)))), ((int)(((byte)(87)))));
            this.btnBusqueda.BackgroundImage = global::Collaress.Properties.Resources.lupa;
            this.btnBusqueda.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnBusqueda.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.btnBusqueda.FlatAppearance.BorderSize = 2;
            this.btnBusqueda.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBusqueda.Location = new System.Drawing.Point(194, 17);
            this.btnBusqueda.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.btnBusqueda.Name = "btnBusqueda";
            this.btnBusqueda.Size = new System.Drawing.Size(35, 35);
            this.btnBusqueda.TabIndex = 5;
            this.btnBusqueda.UseVisualStyleBackColor = false;
            this.btnBusqueda.Click += new System.EventHandler(this.btnBusqueda_Click);
            // 
            // btnCrearWord
            // 
            this.btnCrearWord.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCrearWord.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(153)))), ((int)(((byte)(87)))));
            this.btnCrearWord.BackgroundImage = global::Collaress.Properties.Resources.word;
            this.btnCrearWord.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnCrearWord.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.btnCrearWord.FlatAppearance.BorderSize = 2;
            this.btnCrearWord.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCrearWord.Font = new System.Drawing.Font("Noto Sans", 8.249999F);
            this.btnCrearWord.Location = new System.Drawing.Point(503, 329);
            this.btnCrearWord.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.btnCrearWord.Name = "btnCrearWord";
            this.btnCrearWord.Size = new System.Drawing.Size(35, 35);
            this.btnCrearWord.TabIndex = 2;
            this.btnCrearWord.UseVisualStyleBackColor = false;
            this.btnCrearWord.Click += new System.EventHandler(this.btnImprimir_Click);
            // 
            // VentanaGrafico
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(4)))), ((int)(((byte)(177)))), ((int)(((byte)(103)))));
            this.ClientSize = new System.Drawing.Size(804, 451);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.pictureBox6);
            this.Controls.Add(this.pictureBox3);
            this.Controls.Add(this.pictureBox4);
            this.Controls.Add(this.pictureBox5);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.lblVacaId);
            this.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.MinimumSize = new System.Drawing.Size(820, 490);
            this.Name = "VentanaGrafico";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Graficas?";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.VentanaGrafico_FormClosing);
            this.Load += new System.EventHandler(this.VentanaGrafico_Load);
            ((System.ComponentModel.ISupportInitialize)(this.graficoVacaInfo)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Chart graficoVacaInfo;
        private System.Windows.Forms.Label lblVacaId;
        private System.Windows.Forms.Timer temporizador;
        private System.IO.Ports.SerialPort puerto;
        private System.Windows.Forms.Button btnCrearWord;
        private System.Windows.Forms.ListBox listVacas;
        private System.Windows.Forms.TextBox txtBusqueda;
        private System.Windows.Forms.Button btnBusqueda;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.ToolTip tipBusqueda;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.PictureBox pictureBox4;
        private System.Windows.Forms.PictureBox pictureBox5;
        private System.Windows.Forms.PictureBox pictureBox6;
    }
}

