﻿using Revit_glTF_Exporter;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;

namespace Common_glTF_Exporter.Export
{
    public static class BinFile
    {
        public static void Create(string directory, string filename, List<glTFBinaryData> binaryFileData, bool exportNormals, bool exportBatchId)
        {
            using (FileStream f = File.Create(directory + filename))
            {
                using (BinaryWriter writer = new BinaryWriter(f))
                {
                    foreach (var bin in binaryFileData)
                    {
                        foreach (var coord in bin.vertexBuffer)
                        {
                            writer.Write((float)coord);
                        }                     

                        if (exportBatchId)
                        {
                            foreach (var batchId in bin.batchIdBuffer)
                            {
                                writer.Write((float)batchId);
                            }
                        }

                        foreach (var index in bin.indexBuffer)
                        {
                            writer.Write((int)index);
                        }
                    }
                }
            }
        }
    }
}
