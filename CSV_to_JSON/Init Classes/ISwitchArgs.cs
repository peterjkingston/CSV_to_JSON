﻿namespace CSV_to_JSON
{
    public interface ISwitchArgs
    {
        string TargetFilePath { get; }
        string OutputFile { get; }
    }
}