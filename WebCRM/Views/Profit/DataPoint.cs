using System;
using System.Collections.Generic;
using System.Linq;
using System;
using System.Runtime.Serialization;

namespace WebCRM.Views
{
	//DataContract for Serializing Data - required to serve in JSON format
	[DataContract]
	public class DataPoint
	{
		public DataPoint(string label, double y)
		{
			this.Label = label;
			this.Y = y;
		}

		public DataPoint(string label, bool isCumulativeSum, string indexLabel)
		{
			this.Label = label;
			this.IsCumulativeSum = isCumulativeSum;
			this.IndexLabel = indexLabel;
		}

		//Explicitly setting the name to be used while serializing to JSON.
		[DataMember(Name = "label")]
		public string Label = "";

		//Explicitly setting the name to be used while serializing to JSON.
		[DataMember(Name = "y")]
		public Nullable<double> Y = null;

		//Explicitly setting the name to be used while serializing to JSON.
		[DataMember(Name = "isCumulativeSum")]
		public bool IsCumulativeSum = false;

		//Explicitly setting the name to be used while serializing to JSON.
		[DataMember(Name = "indexLabel")]
		public string IndexLabel = null;
	}
}