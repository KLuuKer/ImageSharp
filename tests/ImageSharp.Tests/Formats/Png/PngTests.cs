﻿// <copyright file="PngTests.cs" company="James Jackson-South">
// Copyright (c) James Jackson-South and contributors.
// Licensed under the Apache License, Version 2.0.
// </copyright>

namespace ImageSharp.Tests
{
    using System.IO;
    using System.Threading.Tasks;

    using Formats;

    using Xunit;

    public class PngTests : FileTestBase
    {
        [Fact]
        public void ImageCanSaveIndexedPng()
        {
            string path = CreateOutputDirectory("Png");

            foreach (TestFile file in Files)
            {
                Image image = file.CreateImage();

                using (FileStream output = File.OpenWrite($"{path}/{file.FileNameWithoutExtension}.png"))
                {
                    image.Quality = 256;
                    image.Save(output, new PngFormat());
                }
            }
        }

        [Fact]
        public void ImageCanSavePngInParallel()
        {
            string path = this.CreateOutputDirectory("Png");

            Parallel.ForEach(
                Files,
                file =>
                    {
                        Image image = file.CreateImage();

                        using (FileStream output = File.OpenWrite($"{path}/{file.FileNameWithoutExtension}.png"))
                        {
                            image.SaveAsPng(output);
                        }
                    });
        }
    }
}