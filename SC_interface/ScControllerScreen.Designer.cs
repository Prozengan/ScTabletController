
namespace ScTabletController
{
    partial class ScControllerScreen
    {
        /// <summary>
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur Windows Form

        /// <summary>
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            this.miningPower = new System.Windows.Forms.TrackBar();
            this.resetInterface = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.landingGears = new System.Windows.Forms.CheckBox();
            this.doorOpening = new System.Windows.Forms.CheckBox();
            this.doorLock = new System.Windows.Forms.CheckBox();
            this.btConnect = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.miningPower)).BeginInit();
            this.SuspendLayout();
            // 
            // miningPower
            // 
            this.miningPower.Location = new System.Drawing.Point(368, 27);
            this.miningPower.Name = "miningPower";
            this.miningPower.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.miningPower.Size = new System.Drawing.Size(45, 390);
            this.miningPower.TabIndex = 2;
            this.miningPower.Scroll += new System.EventHandler(this.miningPower_Scroll);
            // 
            // resetInterface
            // 
            this.resetInterface.BackColor = System.Drawing.Color.DarkSalmon;
            this.resetInterface.Location = new System.Drawing.Point(77, 382);
            this.resetInterface.Name = "resetInterface";
            this.resetInterface.Size = new System.Drawing.Size(128, 56);
            this.resetInterface.TabIndex = 3;
            this.resetInterface.Text = "RESET";
            this.resetInterface.UseVisualStyleBackColor = false;
            this.resetInterface.Click += new System.EventHandler(this.resetInterface_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(365, 420);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(42, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Minage";
            // 
            // landingGears
            // 
            this.landingGears.Appearance = System.Windows.Forms.Appearance.Button;
            this.landingGears.Location = new System.Drawing.Point(26, 27);
            this.landingGears.Name = "landingGears";
            this.landingGears.Size = new System.Drawing.Size(100, 50);
            this.landingGears.TabIndex = 7;
            this.landingGears.Text = "Landing gears";
            this.landingGears.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.landingGears.UseVisualStyleBackColor = true;
            this.landingGears.CheckedChanged += new System.EventHandler(this.landingGears_CheckedChanged);
            // 
            // doorOpening
            // 
            this.doorOpening.Appearance = System.Windows.Forms.Appearance.Button;
            this.doorOpening.Location = new System.Drawing.Point(26, 83);
            this.doorOpening.Name = "doorOpening";
            this.doorOpening.Size = new System.Drawing.Size(100, 50);
            this.doorOpening.TabIndex = 8;
            this.doorOpening.Text = "Door opening";
            this.doorOpening.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.doorOpening.UseVisualStyleBackColor = true;
            this.doorOpening.CheckedChanged += new System.EventHandler(this.doorOpening_CheckedChanged);
            // 
            // doorLock
            // 
            this.doorLock.Appearance = System.Windows.Forms.Appearance.Button;
            this.doorLock.Location = new System.Drawing.Point(132, 83);
            this.doorLock.Name = "doorLock";
            this.doorLock.Size = new System.Drawing.Size(100, 50);
            this.doorLock.TabIndex = 9;
            this.doorLock.Text = "Door lock";
            this.doorLock.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.doorLock.UseVisualStyleBackColor = true;
            this.doorLock.CheckedChanged += new System.EventHandler(this.doorLock_CheckedChanged);
            // 
            // btConnect
            // 
            this.btConnect.Appearance = System.Windows.Forms.Appearance.Button;
            this.btConnect.Location = new System.Drawing.Point(688, 27);
            this.btConnect.Name = "btConnect";
            this.btConnect.Size = new System.Drawing.Size(100, 50);
            this.btConnect.TabIndex = 10;
            this.btConnect.Text = "BT CONNECT";
            this.btConnect.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btConnect.UseVisualStyleBackColor = true;
            this.btConnect.CheckedChanged += new System.EventHandler(this.btConnect_CheckedChanged);
            // 
            // ScControlScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btConnect);
            this.Controls.Add(this.doorLock);
            this.Controls.Add(this.doorOpening);
            this.Controls.Add(this.landingGears);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.resetInterface);
            this.Controls.Add(this.miningPower);
            this.Name = "ScControlScreen";
            this.Text = "SC Control";
            this.Load += new System.EventHandler(this.ScControlScreen_Load);
            ((System.ComponentModel.ISupportInitialize)(this.miningPower)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TrackBar miningPower;
        private System.Windows.Forms.Button resetInterface;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox landingGears;
        private System.Windows.Forms.CheckBox doorOpening;
        private System.Windows.Forms.CheckBox doorLock;
        private System.Windows.Forms.CheckBox btConnect;
    }
}

