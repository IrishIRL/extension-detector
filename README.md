# extension-detector
Extension Detector written on C#

Small application that uses library Winista.Mime (https://github.com/GetoXs/MimeDetect)
Searches in folder with "fileXX", where XX is number for the files that are jpeg, copies them into new folder adding .jpeg to the end. 
New folder name: detected_files/

The app can detect other type of files, but I did not do any action to it, because it was not required.

PS. Since Winista.Mime gives an answers like "image/jpeg" and not "jpeg", it is not possible just to make something like
If value != null {File.Copy(x + "." + value);} (where x is a file name and value is extention). Probably we can convert it ToString and then delete the written before ".../...".
So if it was "image/jpeg" it will automatically count letters before "/" and delete them with slash itself. But meh. I am lazy.
