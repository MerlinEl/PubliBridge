object Form1: TForm1
  Left = 0
  Top = 0
  Caption = 'Call CSharpDll Methods:'
  ClientHeight = 555
  ClientWidth = 842
  Color = clBtnFace
  Font.Charset = DEFAULT_CHARSET
  Font.Color = clWindowText
  Font.Height = -11
  Font.Name = 'Tahoma'
  Font.Style = []
  OldCreateOrder = False
  OnShow = OnFormShown
  PixelsPerInch = 96
  TextHeight = 13
  object GroupBox6: TGroupBox
    Left = 8
    Top = 292
    Width = 826
    Height = 255
    Caption = 'Console:'
    TabOrder = 0
    object TxtConsole: TMemo
      Left = 3
      Top = 13
      Width = 820
      Height = 239
      ReadOnly = True
      TabOrder = 0
    end
  end
  object grp1: TGroupBox
    Left = 8
    Top = 8
    Width = 826
    Height = 278
    Caption = '( DLL ) Walker Player Methods:'
    TabOrder = 1
    object lbl4: TLabel
      Left = 169
      Top = 116
      Width = 41
      Height = 13
      Caption = 'SWF dir:'
    end
    object Label4: TLabel
      Left = 168
      Top = 27
      Width = 55
      Height = 13
      Caption = 'User name:'
    end
    object lbl2: TLabel
      Left = 168
      Top = 87
      Width = 42
      Height = 13
      Caption = 'Book dir:'
    end
    object lbl3: TLabel
      Left = 168
      Top = 145
      Width = 48
      Height = 13
      Caption = 'SWF files:'
    end
    object BtnLoadFile2D: TButton
      Left = 12
      Top = 82
      Width = 141
      Height = 25
      Caption = 'LoadFile2D( fpath )'
      TabOrder = 0
      OnClick = BtnLoadFile2DClick
    end
    object BtnSayHello: TButton
      Left = 12
      Top = 22
      Width = 142
      Height = 25
      Caption = 'SayHello( str )'
      TabOrder = 1
      OnClick = BtnSayHelloClick
    end
    object CbxBookDirs: TComboBox
      Left = 248
      Top = 84
      Width = 496
      Height = 21
      Style = csDropDownList
      ItemIndex = 0
      TabOrder = 2
      Text = 'C:\Users\Orien Star\Dropbox\PubliBridge\Interactive\D'#283'jepis 6'
      OnChange = OnBookDirectoryChanged
      Items.Strings = (
        'C:\Users\Orien Star\Dropbox\PubliBridge\Interactive\D'#283'jepis 6')
    end
    object BtnBrowseDir: TButton
      Left = 750
      Top = 82
      Width = 59
      Height = 25
      Caption = 'Add Dir...'
      TabOrder = 3
      OnClick = BtnBrowseDirClick
    end
    object EdtName: TEdit
      Left = 248
      Top = 24
      Width = 496
      Height = 21
      TabOrder = 4
      Text = 'Mr.Dalibor and Mr.Rene'
    end
    object CbxSwfDirs: TComboBox
      Left = 248
      Top = 113
      Width = 496
      Height = 21
      Style = csDropDownList
      ItemIndex = 0
      TabOrder = 5
      Text = 'root'
      OnChange = OnBookDirectoryChanged
      Items.Strings = (
        'root'
        'lessons'
        '3d'
        'audio'
        'video'
        'photos')
    end
    object ChkAutoPlay: TCheckBox
      Left = 248
      Top = 196
      Width = 141
      Height = 17
      Caption = 'Auto Play'
      Checked = True
      State = cbChecked
      TabOrder = 6
    end
    object CbxSwfFiles: TComboBox
      Left = 248
      Top = 140
      Width = 496
      Height = 21
      Style = csDropDownList
      TabOrder = 7
    end
    object ChkFullScreen: TCheckBox
      Left = 537
      Top = 197
      Width = 141
      Height = 17
      Caption = 'Full Screen'
      Checked = True
      State = cbChecked
      TabOrder = 8
    end
    object ChkHiddenPlayer: TCheckBox
      Left = 537
      Top = 220
      Width = 141
      Height = 17
      Caption = 'Hidden Player'
      TabOrder = 9
    end
    object ChkFitToScreen: TCheckBox
      Left = 684
      Top = 196
      Width = 141
      Height = 17
      Caption = 'Fit To Screen'
      Checked = True
      State = cbChecked
      TabOrder = 10
    end
    object ChkCenterToScreen: TCheckBox
      Left = 685
      Top = 219
      Width = 141
      Height = 17
      Caption = 'Center To Screen'
      Checked = True
      State = cbChecked
      TabOrder = 11
    end
    object ChkEscapeEnabled: TCheckBox
      Left = 685
      Top = 242
      Width = 141
      Height = 17
      Caption = 'Escape Enabled'
      Checked = True
      State = cbChecked
      TabOrder = 12
    end
    object ChkHiddenConsole: TCheckBox
      Left = 538
      Top = 242
      Width = 141
      Height = 17
      Caption = 'Hidden Console'
      Checked = True
      State = cbChecked
      TabOrder = 13
    end
    object ChkSkipLogo: TCheckBox
      Left = 248
      Top = 219
      Width = 141
      Height = 17
      Caption = 'Skip Logo'
      TabOrder = 14
    end
    object BtnLoadFile3D: TButton
      Left = 12
      Top = 113
      Width = 141
      Height = 25
      Caption = 'LoadFile3D( fpath )'
      TabOrder = 15
      OnClick = BtnLoadFile3DClick
    end
  end
end
