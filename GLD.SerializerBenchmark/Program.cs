﻿using System.Collections.Generic;
using System.Runtime.Serialization.Json;
using GLD.SerializerBenchmark.Serializers;
using GLD.SerializerBenchmark.TestData;

namespace GLD.SerializerBenchmark
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var repetitions = int.Parse(args[0]);

            var testDataDescriptions = new List<ITestDataDescription>
            {
                // new IntDescription(), // TODO: Hang up. Investigate.
                // new StringArrayDescription(), // TODO: OutOfMemory exception
                //new SimpleObjectDescription(),
                new TelemetryDescription(),
                new PersonDescription(),
                //new EDI_X12_835Description(),
                //new TestData.NoAtributes.EDI_X12_835Description(),
                //new ObjectGraphDescription(),
                //new MsgBatchingDescription(),
            };
            var serializers = new List<ISerDeser>
            {
                //new AvroSerializer(),  TODO: For some reason it is impossible to pass generic T type to serializer.
                new BinarySerializer(),
                new BondCompactSerializer(), // TODO: works only for Person
                new BondFastSerializer(), // TODO: works only for Person
                new BondJsonSerializer(), // TODO: works only for Person
                new DataContractSerializerSerializer(),
                new DataContractJsonSer(),
                new JavaScriptSerializer(), // TODO: DateTime format?
                new XmlSerializerSer(),
                new ApJsonSerializer(), // TODO: DateTime format?
                new FastJsonSerializer(), // TODO: DateTime format?
                new JilSerializer(), // TODO: DateTime format?
                new JsonFxSerializer(), // TODO: DateTime format?
                new JsonNetHelperSerializer(),
                new JsonNetSerializer(),
                new HaveBoxJSONSerializer(), // TODO: DateTime format?
                new MessageSharkSer(),
                new MsgPackSerializer(), // TODO: DateTime format?
                new NetJSONSer(), // TODO: DateTime format?
                new NetSerializerSer(),
                new NfxJsonSerializer(),
                new NfxSlimSerializer(),
                new ProtoBufSerializer(),
                new SharpSerializer(), // TODO: DateTime format?
                new ServiceStackJsonSerializer(), // TODO: DateTime format?
                new ServiceStackTypeSerializer(), // TODO: DateTime format?
                new SalarBoisSerializer()
            };

            Tester.Tests(serializers, testDataDescriptions, repetitions);
        }
    }
}