using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfTests.MVVM.Model;

namespace WpfTests.Services
{
    class FileIOService
    {

        public BindingList<TextQuestion> LoadData(string PATH)
        {
            var fileExists = File.Exists(PATH);
            if (!fileExists)
            {
                File.CreateText(PATH).Dispose();
                SaveData(new BindingList<TextQuestion>(){ new TextQuestion {question="",rightAnswer=1 } },PATH);
            }
            using (var reader = File.OpenText(PATH))
            {
                var fileText = reader.ReadToEnd();
                return JsonConvert.DeserializeObject<BindingList<TextQuestion>>(fileText);
            }
        }

        public void SaveData(object DataList, string PATH)
        {
            using (StreamWriter writer = File.CreateText(PATH))
            {
                string output = JsonConvert.SerializeObject(DataList);
                writer.Write(output);
            }
        }

    }
}
