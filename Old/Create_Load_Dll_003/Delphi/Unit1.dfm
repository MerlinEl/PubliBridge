object Form1: TForm1
  Left = 0
  Top = 0
  Caption = 'Call CSharpDll Methods:'
  ClientHeight = 495
  ClientWidth = 402
  Color = clBtnFace
  Font.Charset = DEFAULT_CHARSET
  Font.Color = clWindowText
  Font.Height = -11
  Font.Name = 'Tahoma'
  Font.Style = []
  OldCreateOrder = False
  OnCreate = OnFormCreate
  PixelsPerInch = 96
  TextHeight = 13
  object Label2: TLabel
    Left = 9
    Top = 326
    Width = 42
    Height = 13
    Caption = 'Console:'
  end
  object GroupBox1: TGroupBox
    Left = 8
    Top = 8
    Width = 385
    Height = 89
    Caption = 'Maths:'
    TabOrder = 1
    object Label1: TLabel
      Left = 244
      Top = 23
      Width = 21
      Height = 13
      Caption = 'valA'
    end
    object Label3: TLabel
      Left = 307
      Top = 23
      Width = 20
      Height = 13
      Caption = 'valB'
    end
    object BtnMin: TButton
      Left = 12
      Top = 17
      Width = 209
      Height = 25
      Caption = 'Math.Min(valA, valB)'
      TabOrder = 0
      OnClick = BtnMinClick
    end
    object EdtValA: TEdit
      Left = 244
      Top = 41
      Width = 57
      Height = 21
      TabOrder = 1
      Text = '5'
    end
    object EdtValB: TEdit
      Left = 307
      Top = 41
      Width = 65
      Height = 21
      TabOrder = 2
      Text = '10'
    end
    object BtnMax: TButton
      Left = 12
      Top = 48
      Width = 209
      Height = 25
      Caption = 'Math.Max(valA, valB)'
      TabOrder = 3
      OnClick = BtnMaxClick
    end
  end
  object TxtConsole: TMemo
    Left = 9
    Top = 345
    Width = 385
    Height = 138
    ReadOnly = True
    TabOrder = 0
  end
  object GroupBox2: TGroupBox
    Left = 8
    Top = 103
    Width = 385
    Height = 122
    Caption = 'Strings:'
    TabOrder = 2
    object Label4: TLabel
      Left = 252
      Top = 36
      Width = 13
      Height = 13
      Caption = 'str'
    end
    object BtnSayHello: TButton
      Left = 12
      Top = 80
      Width = 209
      Height = 25
      Caption = 'SayHello(str)'
      TabOrder = 0
      OnClick = BtnSayHelloClick
    end
    object EdtName: TEdit
      Left = 251
      Top = 55
      Width = 121
      Height = 21
      TabOrder = 1
      Text = 'Mr.John'
    end
    object BtnMsgBox: TButton
      Left = 12
      Top = 49
      Width = 209
      Height = 25
      Caption = 'MessageBox.Show(str)'
      TabOrder = 2
      OnClick = BtnShowMsgStrClick
    end
    object Button1: TButton
      Left = 12
      Top = 18
      Width = 209
      Height = 25
      Caption = 'MessageBox.Show(int)'
      TabOrder = 3
      OnClick = BtnShowMsgIntClick
    end
  end
  object GroupBox3: TGroupBox
    Left = 8
    Top = 231
    Width = 385
    Height = 90
    Caption = 'Forms:'
    TabOrder = 3
    object BtnShowPanel: TButton
      Left = 12
      Top = 22
      Width = 209
      Height = 25
      Caption = 'ShowGalleryPanel()'
      TabOrder = 0
      OnClick = BtnShowPanelClick
    end
    object Button2: TButton
      Left = 12
      Top = 53
      Width = 209
      Height = 25
      Caption = 'ShowSWFPanel()'
      TabOrder = 1
      OnClick = BtnShowSWFPanel
    end
  end
end
