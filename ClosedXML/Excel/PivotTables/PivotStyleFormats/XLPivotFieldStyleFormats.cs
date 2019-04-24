﻿// Keep this file CodeMaid organised and cleaned

using System.Collections.Generic;

namespace ClosedXML.Excel
{
    internal class XLPivotFieldStyleFormats : IXLPivotFieldStyleFormats
    {
        private readonly List<IXLPivotValueStyleFormat> _dataValuesFormats = new List<IXLPivotValueStyleFormat>();
        private IXLPivotStyleFormat _headerFormat;
        private IXLPivotStyleFormat _labelFormat;
        private IXLPivotElementStyleFormats _subtotalFormat;

        public XLPivotFieldStyleFormats(IXLPivotField field)
        {
            PivotField = field;
        }

        public IXLPivotField PivotField { get; }

        #region IXLPivotFieldStyleFormats

        public IXLPivotValueStyleFormat AddValuesFormat()
        {
            var dataValuesFormat = new XLPivotValueStyleFormat(PivotField)
            {
                AppliesTo = XLPivotStyleFormatElement.Data
            };
            _dataValuesFormats.Add(dataValuesFormat);
            return dataValuesFormat;
        }

        public IEnumerable<IXLPivotValueStyleFormat> DataValuesFormats => _dataValuesFormats;

        public IXLPivotStyleFormat Header
        {
            get
            {
                if (_headerFormat == null)
                {
                    _headerFormat = new XLPivotStyleFormat(PivotField);
                }
                return _headerFormat;
            }
            set { _headerFormat = value; }
        }

        public bool HasLabelFormat => _labelFormat != null;

        public IXLPivotStyleFormat Label
        {
            get
            {
                if (_labelFormat == null)
                {
                    _labelFormat = new XLPivotStyleFormat(PivotField)
                    {
                        AppliesTo = XLPivotStyleFormatElement.Label
                    };
                }
                return _labelFormat;
            }
            set { _labelFormat = value; }
        }

        public IXLPivotElementStyleFormats Subtotal
        {
            get
            {
                if (_subtotalFormat == null)
                {
                    _subtotalFormat = new XLPivotSubtotalStyleFormats(PivotField);
                }

                return _subtotalFormat;
            }
            set { _subtotalFormat = value; }
        }

        #endregion IXLPivotFieldStyleFormats
    }
}