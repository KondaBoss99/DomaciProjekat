using FTN.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FTN.Services.NetworkModelService.DataModel.Entities
{
    public class Switch : ConductingEquipment
    {
		private bool normalOpen;
		private float ratedCurrent;
		private bool retained;
		private int switchOnCount;
		private DateTime switchOnDate;

		public Switch(long globalId) : base(globalId)
		{
		}
		public bool NormalOpen
		{
			get
			{
				return normalOpen;
			}

			set
			{
				normalOpen = value;
			}
		}
		public float RatedCurrent
		{
			get
			{
				return ratedCurrent;
			}

			set
			{
				ratedCurrent = value;
			}
		}
		public bool Retained
		{
			get
			{
				return retained;
			}

			set
			{
				retained = value;
			}
		}
		public int SwitchOnCount
		{
			get
			{
				return switchOnCount;
			}

			set
			{
				switchOnCount = value;
			}
		}
		public DateTime SwitchOnDate
		{
			get
			{
				return switchOnDate;
			}

			set
			{
				switchOnDate = value;
			}
		}

		public override bool Equals(object obj)
		{
			if (base.Equals(obj))
			{
				Switch x = (Switch)obj;
				return (x.NormalOpen == this.NormalOpen) &&
					   (x.RatedCurrent == this.RatedCurrent) &&
					   (x.Retained == this.Retained) &&
					   (x.SwitchOnCount == this.SwitchOnCount) &&
					   (x.SwitchOnDate == this.SwitchOnDate);
			}
			else
			{
				return false;
			}
		}

		public override int GetHashCode()
		{
			return base.GetHashCode();
		}


		#region IAccess implementation

		public override bool HasProperty(ModelCode t)
		{
			switch (t)
			{
				case ModelCode.SWITCH_NORMALOPEN:
					return true;
				case ModelCode.SWITCH_RATEDCURRENT:
					return true;
				case ModelCode.SWITCH_RETAINED:
					return true;
				case ModelCode.SWITCH_SWITCHONCOUNT:
					return true;
				case ModelCode.SWITCH_SWITCHONDATE:
					return true;

				default:
					return base.HasProperty(t);
			}
		}

		public override void GetProperty(Property prop)
		{
			switch (prop.Id)
			{
				case ModelCode.SWITCH_NORMALOPEN:
					prop.SetValue(normalOpen);
					break;
				case ModelCode.SWITCH_RATEDCURRENT:
					prop.SetValue(ratedCurrent);
					break;
				case ModelCode.SWITCH_RETAINED:
					prop.SetValue(retained);
					break;
				case ModelCode.SWITCH_SWITCHONCOUNT:
					prop.SetValue(switchOnCount);
					break;
				case ModelCode.SWITCH_SWITCHONDATE:
					prop.SetValue(switchOnDate);
					break;

				default:
					base.GetProperty(prop);
					break;
			}
		}

		public override void SetProperty(Property property)
		{
			switch (property.Id)
			{
				case ModelCode.SWITCH_NORMALOPEN:
					normalOpen = property.AsBool();
					break;
				case ModelCode.SWITCH_RATEDCURRENT:
					ratedCurrent = property.AsFloat();
					break;
				case ModelCode.SWITCH_RETAINED:
					retained = property.AsBool();
					break;
				case ModelCode.SWITCH_SWITCHONCOUNT:
					switchOnCount = property.AsInt();
					break;
				case ModelCode.SWITCH_SWITCHONDATE:
					switchOnDate = property.AsDateTime();
					break;

				default:
					base.SetProperty(property);
					break;
			}
		}

		#endregion IAccess implementation	
	}
}
