// Copyright (c) Microsoft Corporation.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Microsoft.PowerPlatform.Formulas.Tools.Schemas
{
    internal enum ContentKind
    {
        Unknown,
        Image,
        Audio,
        Video,
        Pdf,
    }

    internal enum ResourceKind
    {
        LocalFile,
        Uri,
    }

    // these are the schema types used by the server to identify what type of resource is it.
    // i - refers to image files
    // m - refers to media files - audio/video
    // o - refers to pdf files
    internal enum Schema
    {
        i,
        m,
        o
    }

    internal class ResourcesJson
    {
        public ResourceJson[] Resources { get; set; }
    }

    internal class ResourceJson
    {
        public string Name { get; set; }
        public string FileName { get; set; }
        public ResourceKind ResourceKind { get; set; }
        public string Path { get; set; }
        public ContentKind Content { get; set; }

        // These are the schema types used by the server to identify what type of resource is it.
        // i - refers to image files
        // m - refers to media files - audio/video
        // o - refers to pdf files
        // ? - refers to unknown types
        public string Schema { get; set; }
        public string Type { get; set; }
        public bool IsSampleData { get; set; }
        public bool IsWritable { get; set; }

        // For LocalFiles, this root path is regenerated by the server during load, and points to a temporary resource url
        // There is no impact if it's missing.
        // We preserve it in Entropy.json for roundtrip purposes only.
        public string RootPath { get; set; }

        [JsonExtensionData]
        public Dictionary<string, JsonElement> ExtensionData { get; set; }
    }
}
