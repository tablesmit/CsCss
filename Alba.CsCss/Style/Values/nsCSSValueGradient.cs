﻿using System.Collections.Generic;

namespace Alba.CsCss.Style
{
    public class nsCSSValueGradient
    {
        internal readonly List<nsCSSValueGradientStop> mStops = new List<nsCSSValueGradientStop>();
        internal readonly nsCSSValue[] mRadialValues = new nsCSSValue[2];
        internal bool mIsRadial, mIsRepeating, mIsExplicitSize, mIsLegacySyntax;
        internal nsCSSValuePair mBgPos;
        internal nsCSSValue mAngle;

        internal nsCSSValueGradient (bool aIsRadial, bool aIsRepeating)
        {
            mIsRadial = aIsRadial;
            mIsRepeating = aIsRepeating;
        }

        internal nsCSSValue GetRadialShape ()
        {
            return mRadialValues[0];
        }

        internal nsCSSValue GetRadialSize ()
        {
            return mRadialValues[1];
        }

        internal nsCSSValue GetRadiusX ()
        {
            return mRadialValues[0];
        }

        internal nsCSSValue GetRadiusY ()
        {
            return mRadialValues[1];
        }

        // public interface

        public IEnumerable<nsCSSValueGradientStop> Stops
        {
            get { return mStops.AsReadOnly(); }
        }

        public bool IsRadial
        {
            get { return mIsRadial; }
        }

        public bool IsRepeating
        {
            get { return mIsRepeating; }
        }

        public bool IsExplicitSize
        {
            get { return mIsExplicitSize; }
        }

        public nsCSSValuePair BgPos
        {
            get { return mBgPos; }
        }

        public nsCSSValue Angle
        {
            get { return mAngle; }
        }

        public nsCSSValue RadialShape
        {
            get { return mRadialValues[0]; }
        }

        public nsCSSValue RadialSize
        {
            get { return mRadialValues[1]; }
        }

        public nsCSSValue RadiusX
        {
            get { return mRadialValues[0]; }
        }

        public nsCSSValue RadiusY
        {
            get { return mRadialValues[1]; }
        }
    }
}