unit WalkerPlayerCmd;

interface

uses WalkerPlayerOptions, WalkerPlayerUtils, WalkerPlayer, System.SysUtils,
Vcl.Forms, Vcl.Dialogs, Winapi.Windows;

  procedure PlayImages(options :OWPlayer; fname :string);
  procedure PlayAudio(options :OWPlayer; fname :string);
  procedure PlayLesson(options :OWPlayer; fname :string);
  procedure PlayVideo(options :OWPlayer; fname :string);
  procedure Play3D(options :OWPlayer; fname :string);

implementation

  uses MainForm;
  type tt = record
    b1:Boolean;
    b2:Boolean;

  end;
  procedure PlayLesson(options :OWPlayer; fname :string);
   var res:Integer;
  begin
    options.Name := 'Lesson Player:';
    options.MediaType := 'LESSONS';
    options.FileName := fname; // 004.swf
    // Button ID ( 04 ) < 04.swf
    options.ButtonID := ExtractFNameWithoutExt(fname);
    WPlayer.LoadFile(options);

    // Log
    Form1.LogClear();
    Form1.Log('Lesson Player:'+ WPlayer.OptionsToString(options));
    WPlayer.Log('Delphi ( MainForm )', WPlayer.OptionsToString(options));

    // Test
    //res := SizeOf(tt);
    end;

  procedure Play3D(options :OWPlayer; fname :string);
  begin
    options.Name := '3D Player:';
    options.MediaType := 'STAGE3D';
    options.FileName := fname; // 158.swf
    // Button ID ( 158 ) < 158.swf
    options.ButtonID := ExtractFNameWithoutExt(fname);
    WPlayer.LoadFile(options);

    // Log
    Form1.LogClear();
    Form1.Log('3D Player:'+ WPlayer.OptionsToString(options));
    WPlayer.Log('Delphi ( MainForm )', WPlayer.OptionsToString(options));
    end;

  procedure PlayVideo(options :OWPlayer; fname :string);
  begin
    options.Name := 'Video Player:';
    options.MediaType := 'VIDEO';
    options.FileName := fname; // 158.swf or https://www...
    // Button ID ( 158 or WEBLINK or 'WEBSTREAM' ) < 158.swf or https://www...
    options.ButtonID := GetVideoID(fname);
    WPlayer.LoadFile(options);

    // Log
    Form1.LogClear();
    Form1.Log('Video Player:'+ WPlayer.OptionsToString(options));
    WPlayer.Log('Delphi ( MainForm )', WPlayer.OptionsToString(options));
    end;

  procedure PlayAudio(options :OWPlayer; fname :string);
  begin
    options.Name := 'Audio Player:';
    options.MediaType := 'AUDIO';
    options.FileName := fname; // 04_01.swf
    // Button ID ( 04_01 ) < 04_01.swf
    // 04 > page     > number of current page
    // 01 > count    > sequence index
    options.ButtonID := ExtractFNameWithoutExt(fname);
    options.WindowSize := '240,140';
    options.WindowPos := 'CENTER'; // 'CENTER' or pos '100,200'
    WPlayer.LoadFile(options);

    // Log
    Form1.LogClear();
    Form1.Log('Audio Player:'+ WPlayer.OptionsToString(options));
    WPlayer.Log('Delphi ( MainForm )', WPlayer.OptionsToString(options));
    end;

  procedure PlayImages(options :OWPlayer; fname :string);
  var btnID: string;
  begin
    options.Name := 'Image Player:';
    options.MediaType := 'IMAGES';
    options.FileName := fname; // 20_01_01_me�oun obecn�.jpg
    // IMAGE_ID ( 24_01_01 ) < 20_01_01_me�oun obecn�.jpg
    // 24 > page     > number of current page
    // 01 > set      > images group
    // 01 > count    > sequence index
    btnID := ExtractFNameWithoutExt(options.FileName); // 20_01_01_me�oun obecn�
    btnID := btnID.SubString(0, btnID.LastIndexOf('_')); // 24_01_01
    options.ButtonID := btnID.SubString(0, btnID.LastIndexOf('_')); // 24_01
    // center on screen or set pos exam(100,200)
    WPlayer.LoadFile(options);

    // Log
    Form1.LogClear();
    Form1.Log('Image Player:'+ WPlayer.OptionsToString(options));
    WPlayer.Log('Delphi ( MainForm )', WPlayer.OptionsToString(options));
  end;
{
Embed link: <iframe width="1280" height="720" src="https://www.youtube.com/embed/6ldHiLvbVe0" title="YouTube video player" frameborder="0" allow="accelerometer; autoplay; clipboard-write; encrypted-media; gyroscope; picture-in-picture" allowfullscreen></iframe>
}
end.
