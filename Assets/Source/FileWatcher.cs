using System;
using System.IO;
using UnityEngine;

public class FileWatcher
{
    public void Start(string folderPath, string fileName, FileSystemEventHandler onChanged)
    {
        // Create a new FileSystemWatcher and set its properties.
        FileSystemWatcher watcher = new FileSystemWatcher();
        watcher.Path = folderPath;

        // Watch for changes in LastAccess and LastWrite times, and
        // the renaming of files or directories.
        watcher.NotifyFilter = NotifyFilters.LastAccess
                               | NotifyFilters.LastWrite
                               | NotifyFilters.FileName
                               | NotifyFilters.DirectoryName;

        // Only watch text files.
        watcher.Filter = fileName;

        // Add event handlers.
        watcher.Changed += onChanged;
        watcher.Created += onChanged;
        watcher.Deleted += onChanged;

        // Begin watching.
        watcher.EnableRaisingEvents = true;
    }
}