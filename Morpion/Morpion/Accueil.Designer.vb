<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Accueil
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        components = New ComponentModel.Container()
        GHButton = New Button()
        MHButton = New Button()
        DHButton = New Button()
        BindingSource1 = New BindingSource(components)
        GMButton = New Button()
        MMButton = New Button()
        DMButton = New Button()
        GBButton = New Button()
        MBButton = New Button()
        DBButton = New Button()
        QuitButton = New Button()
        FinTextBox = New TextBox()
        RejouerButton = New Button()
        OrdiButton = New Button()
        CType(BindingSource1, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' GHButton
        ' 
        GHButton.Font = New Font("Segoe UI", 20F)
        GHButton.Location = New Point(100, 107)
        GHButton.Name = "GHButton"
        GHButton.Size = New Size(135, 109)
        GHButton.TabIndex = 0
        GHButton.UseVisualStyleBackColor = True
        ' 
        ' MHButton
        ' 
        MHButton.Font = New Font("Segoe UI", 20F)
        MHButton.Location = New Point(258, 107)
        MHButton.Name = "MHButton"
        MHButton.Size = New Size(134, 109)
        MHButton.TabIndex = 1
        MHButton.UseVisualStyleBackColor = True
        ' 
        ' DHButton
        ' 
        DHButton.Font = New Font("Segoe UI", 20F)
        DHButton.Location = New Point(413, 107)
        DHButton.Name = "DHButton"
        DHButton.Size = New Size(125, 109)
        DHButton.TabIndex = 2
        DHButton.UseVisualStyleBackColor = True
        ' 
        ' GMButton
        ' 
        GMButton.Font = New Font("Segoe UI", 20F)
        GMButton.Location = New Point(100, 234)
        GMButton.Name = "GMButton"
        GMButton.Size = New Size(135, 110)
        GMButton.TabIndex = 3
        GMButton.UseVisualStyleBackColor = True
        ' 
        ' MMButton
        ' 
        MMButton.Font = New Font("Segoe UI", 20F)
        MMButton.Location = New Point(258, 234)
        MMButton.Name = "MMButton"
        MMButton.Size = New Size(134, 110)
        MMButton.TabIndex = 4
        MMButton.UseVisualStyleBackColor = True
        ' 
        ' DMButton
        ' 
        DMButton.Font = New Font("Segoe UI", 20F)
        DMButton.Location = New Point(413, 234)
        DMButton.Name = "DMButton"
        DMButton.Size = New Size(125, 110)
        DMButton.TabIndex = 5
        DMButton.UseVisualStyleBackColor = True
        ' 
        ' GBButton
        ' 
        GBButton.Font = New Font("Segoe UI", 20F)
        GBButton.Location = New Point(100, 360)
        GBButton.Name = "GBButton"
        GBButton.Size = New Size(135, 108)
        GBButton.TabIndex = 6
        GBButton.UseVisualStyleBackColor = True
        ' 
        ' MBButton
        ' 
        MBButton.Font = New Font("Segoe UI", 20F)
        MBButton.Location = New Point(258, 360)
        MBButton.Name = "MBButton"
        MBButton.Size = New Size(134, 108)
        MBButton.TabIndex = 7
        MBButton.UseVisualStyleBackColor = True
        ' 
        ' DBButton
        ' 
        DBButton.Font = New Font("Segoe UI", 20F)
        DBButton.Location = New Point(413, 360)
        DBButton.Name = "DBButton"
        DBButton.Size = New Size(125, 108)
        DBButton.TabIndex = 8
        DBButton.UseVisualStyleBackColor = True
        ' 
        ' QuitButton
        ' 
        QuitButton.Location = New Point(877, 458)
        QuitButton.Name = "QuitButton"
        QuitButton.Size = New Size(158, 104)
        QuitButton.TabIndex = 9
        QuitButton.Text = "Quitter"
        QuitButton.UseVisualStyleBackColor = True
        ' 
        ' FinTextBox
        ' 
        FinTextBox.Enabled = False
        FinTextBox.Location = New Point(755, 12)
        FinTextBox.Multiline = True
        FinTextBox.Name = "FinTextBox"
        FinTextBox.Size = New Size(280, 141)
        FinTextBox.TabIndex = 10
        FinTextBox.Visible = False
        ' 
        ' RejouerButton
        ' 
        RejouerButton.Location = New Point(874, 321)
        RejouerButton.Name = "RejouerButton"
        RejouerButton.Size = New Size(161, 114)
        RejouerButton.TabIndex = 11
        RejouerButton.Text = "Rejouer"
        RejouerButton.UseVisualStyleBackColor = True
        ' 
        ' OrdiButton
        ' 
        OrdiButton.Location = New Point(874, 180)
        OrdiButton.Name = "OrdiButton"
        OrdiButton.Size = New Size(161, 119)
        OrdiButton.TabIndex = 12
        OrdiButton.Text = "Jouer contre l'ordinateur"
        OrdiButton.UseVisualStyleBackColor = True
        ' 
        ' Accueil
        ' 
        AutoScaleDimensions = New SizeF(10F, 25F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(1047, 574)
        Controls.Add(OrdiButton)
        Controls.Add(RejouerButton)
        Controls.Add(FinTextBox)
        Controls.Add(QuitButton)
        Controls.Add(DBButton)
        Controls.Add(MBButton)
        Controls.Add(GBButton)
        Controls.Add(DMButton)
        Controls.Add(MMButton)
        Controls.Add(GMButton)
        Controls.Add(DHButton)
        Controls.Add(MHButton)
        Controls.Add(GHButton)
        Name = "Accueil"
        Text = "Accueil"
        CType(BindingSource1, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents GHButton As Button
    Friend WithEvents MHButton As Button
    Friend WithEvents DHButton As Button
    Friend WithEvents BindingSource1 As BindingSource
    Friend WithEvents GMButton As Button
    Friend WithEvents MMButton As Button
    Friend WithEvents DMButton As Button
    Friend WithEvents GBButton As Button
    Friend WithEvents MBButton As Button
    Friend WithEvents DBButton As Button
    Friend WithEvents QuitButton As Button
    Friend WithEvents FinTextBox As TextBox
    Friend WithEvents RejouerButton As Button
    Friend WithEvents OrdiButton As Button

End Class
