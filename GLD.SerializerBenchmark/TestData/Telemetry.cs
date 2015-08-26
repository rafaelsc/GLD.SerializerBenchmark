﻿using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using NFX;
using ProtoBuf;

namespace GLD.SerializerBenchmark.TestData
{
   public class TelemetryDescription : ITestDataDescription
    {
        public string Name { get { return "Telemetry"; }}
       public string Description { get{ return "Plain object with numbers and IDs"; }}
       public Type DataType { get { return typeof (TelemetryData); } }
        public List<Type> SecondaryDataTypes { get { return null; } }

        private readonly TelemetryData _data = TelemetryData.Generate(100);

        public object Data { get { return _data; }  }
    }
    [ProtoContract]
    [DataContract]
    [Serializable]
    public class TelemetryData
    {
        ///// <summary>
        ///// Required by some serilizers (i.e. XML)
        ///// </summary>
        //public SimleObject() { }       

 
        [ProtoMember(1)]
        [DataMember]
        public string Id;

        [ProtoMember(2)]
        [DataMember]
        public string DataSource;

        [ProtoMember(3)]
        [DataMember]
        public DateTime TimeStamp;

        [ProtoMember(4)]
        [DataMember]
        public int Param1;

        [ProtoMember(5)]
        [DataMember]
        public uint Param2;

        [ProtoMember(6)]
        [DataMember]
        public double[] Measurements;

        [ProtoMember(7)]
        [DataMember]
        public long AssociatedProblemID;

        [ProtoMember(8)]
        [DataMember]
        public long AssociatedLogID;

        [ProtoMember(9)]
        [DataMember]
        public bool WasProcessed;

        public static TelemetryData Generate(int measurementsNumber)
        {
            var data = new TelemetryData()
            {
                Id = Guid.NewGuid().ToString(),
                DataSource = Guid.NewGuid().ToString(),
                TimeStamp = DateTime.Now,
                Param1 = ExternalRandomGenerator.Instance.NextRandomInteger,
                Param2 = (uint)ExternalRandomGenerator.Instance.NextRandomInteger,
                Measurements = new double[measurementsNumber],
                AssociatedProblemID = 123,
                AssociatedLogID = 89032,
                WasProcessed = true
            };
            for (var i = 0; i < measurementsNumber; i++)
                data.Measurements[i] = ExternalRandomGenerator.Instance.NextRandomDouble;
            return data;
        }
    }
}