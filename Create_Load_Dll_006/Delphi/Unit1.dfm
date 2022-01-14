object Form1: TForm1
  Left = 0
  Top = 0
  Caption = 'Call CSharpDll Methods:'
  ClientHeight = 783
  ClientWidth = 837
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
  object GroupBox4: TGroupBox
    Left = 8
    Top = 8
    Width = 410
    Height = 331
    Caption = 'Static Methods:'
    TabOrder = 0
    object GroupBox1: TGroupBox
      Left = 22
      Top = 34
      Width = 385
      Height = 89
      Caption = 'Maths:'
      TabOrder = 0
      object BtnMin: TButton
        Left = 12
        Top = 17
        Width = 119
        Height = 25
        Caption = 'Min(valA, valB)'
        TabOrder = 0
        OnClick = BtnMinClick
      end
      object BtnMax: TButton
        Left = 12
        Top = 48
        Width = 119
        Height = 25
        Caption = 'Max(valA, valB)'
        TabOrder = 1
        OnClick = BtnMaxClick
      end
    end
    object GroupBox2: TGroupBox
      Left = 16
      Top = 111
      Width = 385
      Height = 122
      Caption = 'Strings:'
      TabOrder = 1
      object BtnSayHello: TButton
        Left = 18
        Top = 50
        Width = 119
        Height = 25
        Caption = 'CombineStrings(a, b)'
        TabOrder = 0
        OnClick = BtnSayHelloClick
      end
    end
    object GroupBox3: TGroupBox
      Left = 16
      Top = 238
      Width = 385
      Height = 90
      Caption = 'Forms:'
      TabOrder = 2
      object BtnShowGalleryPanel: TButton
        Left = 12
        Top = 22
        Width = 125
        Height = 25
        Caption = 'ShowGalleryPanel()'
        TabOrder = 0
        OnClick = BtnShowGalleryPanelClick
      end
      object Button2: TButton
        Left = 12
        Top = 53
        Width = 125
        Height = 25
        Caption = 'ShowSWFPanel()'
        TabOrder = 1
        OnClick = BtnShowSWFPanel
      end
      object BtnLoadFlFromPath: TButton
        Left = 156
        Top = 53
        Width = 125
        Height = 25
        Caption = 'ShowSWFPanel(fpath)'
        TabOrder = 2
        OnClick = BtnLoadFlFromPathClick
      end
    end
  end
  object GroupBox5: TGroupBox
    Left = 424
    Top = 8
    Width = 409
    Height = 331
    Caption = 'Instance Methods:'
    TabOrder = 1
    object GroupBox7: TGroupBox
      Left = 16
      Top = 24
      Width = 385
      Height = 81
      Caption = 'Maths'
      TabOrder = 0
      object BtnInst: TButton
        Left = 11
        Top = 15
        Width = 142
        Height = 25
        Caption = 'Plus(valA, valB)'
        TabOrder = 0
        OnClick = BtnInstPlusClick
      end
      object Button3: TButton
        Left = 11
        Top = 46
        Width = 142
        Height = 25
        Caption = 'SayHello(str)'
        TabOrder = 1
        OnClick = Button3Click
      end
      object BtnLoadClass: TButton
        Left = 240
        Top = 15
        Width = 129
        Height = 25
        Caption = 'Add'
        TabOrder = 2
        OnClick = BtnInstAddClick
      end
    end
    object grp1: TGroupBox
      Left = 16
      Top = 238
      Width = 385
      Height = 90
      Caption = 'Forms:'
      TabOrder = 1
      object BtnInstShowSWFPanel: TButton
        Left = 12
        Top = 53
        Width = 141
        Height = 25
        Caption = 'ShowSWFPanel()'
        TabOrder = 0
        OnClick = BtnInstShowSWFPanelClick
      end
      object BtnInstShowGalleryPanel: TButton
        Left = 12
        Top = 22
        Width = 141
        Height = 25
        Caption = 'ShowGalleryPanel()'
        TabOrder = 1
        OnClick = BtnInstShowGalleryPanelClick
      end
      object BtnInstLoadFile: TButton
        Left = 172
        Top = 53
        Width = 141
        Height = 25
        Caption = 'ShowSWFPanel(fpath)'
        TabOrder = 2
        OnClick = BtnInstLoadFileClick
      end
    end
  end
  object GroupBox6: TGroupBox
    Left = 8
    Top = 345
    Width = 825
    Height = 255
    Caption = 'Console:'
    TabOrder = 2
    object TxtConsole: TMemo
      Left = 3
      Top = 13
      Width = 814
      Height = 239
      ReadOnly = True
      TabOrder = 0
    end
  end
  object GroupBox8: TGroupBox
    Left = 8
    Top = 606
    Width = 825
    Height = 171
    Caption = 'Parameters:'
    TabOrder = 3
    object lbl1: TLabel
      Left = 40
      Top = 50
      Width = 24
      Height = 13
      Caption = 'valB:'
    end
    object lbl2: TLabel
      Left = 40
      Top = 21
      Width = 25
      Height = 13
      Caption = 'valA:'
    end
    object Label4: TLabel
      Left = 40
      Top = 78
      Width = 55
      Height = 13
      Caption = 'User name:'
    end
    object lbl3: TLabel
      Left = 40
      Top = 107
      Width = 48
      Height = 13
      Caption = 'SWF files:'
    end
    object lbl4: TLabel
      Left = 40
      Top = 134
      Width = 41
      Height = 13
      Caption = 'SWF dir:'
    end
    object EdtValA: TEdit
      Left = 106
      Top = 14
      Width = 121
      Height = 21
      TabOrder = 0
      Text = '5'
    end
    object EdtValB: TEdit
      Left = 106
      Top = 44
      Width = 121
      Height = 21
      TabOrder = 1
      Text = '10'
    end
    object EdtName: TEdit
      Left = 106
      Top = 75
      Width = 121
      Height = 21
      TabOrder = 2
      Text = 'Mr.Rene'
    end
    object CbxSwfNames: TComboBox
      Left = 106
      Top = 102
      Width = 121
      Height = 21
      Style = csDropDownList
      TabOrder = 3
    end
    object CbxSwfPaths: TComboBox
      Left = 106
      Top = 129
      Width = 632
      Height = 21
      Style = csDropDownList
      ItemIndex = 0
      TabOrder = 4
      Text = 'E:\Aprog\Orien\FlashC#\PubliBridge\Resources\swf\'
      OnChange = OnDirectoryChanged
      Items.Strings = (
        'E:\Aprog\Orien\FlashC#\PubliBridge\Resources\swf\'
        'C:\Aprog\Orien\FlashC#\PubliBridge\Resources\swf\')
    end
    object BtnBrowseDir: TButton
      Left = 744
      Top = 128
      Width = 73
      Height = 25
      Caption = 'Add Dir...'
      TabOrder = 5
      OnClick = BtnBrowseDirClick
    end
  end
end
