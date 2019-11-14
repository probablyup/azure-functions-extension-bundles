﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Build
{
    public class IndexV2
    {
        public string DefaultVersionRange { get; set; } = "[1.*, 2.0.0)";

        public Dictionary<string, Dictionary<string, string>> BundleVersions { get; set; } = new Dictionary<string, Dictionary<string, string>>();

        public Template Templates { get; set; } = new Template();

        public class Template
        {
            public Dictionary<string, BundleResource> v1 { get; set; } = new Dictionary<string, BundleResource>();
        }

        public class BundleResource
        {
            public string Functions { get; set; }

            public string Bindings { get; set; }

            public string Resources { get; set; }
        }

        public void Add(string version, BundleResource resource)
        {
            BundleVersions.Add(version,
                new Dictionary<string, string>()
                {
                    { "templates", version }
                });

            Templates.v1.Add(version, resource);
        }
    }
}