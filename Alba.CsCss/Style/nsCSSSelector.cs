﻿using System;
using System.Collections.Generic;
using Alba.CsCss.Internal.Extensions;

namespace Alba.CsCss.Style
{
    public class nsCSSSelector
    {
        // For case-sensitive documents, mLowercaseTag is the same as mCasedTag, but in case-insensitive documents (HTML) mLowercaseTag is lowercase.
        // Also, for pseudo-elements mCasedTag will be null but mLowercaseTag contains their name.
        internal string mLowercaseTag, mCasedTag;
        internal int mNameSpace = nsNameSpace.Unknown;
        internal char mOperator;
        internal nsCSSSelector mNegations;
        internal nsCSSPseudoElement mPseudoType = nsCSSPseudoElement.NotPseudoElement;
        internal nsAtomList mIDList, mClassList;
        internal nsPseudoClassList mPseudoClassList;
        internal nsAttrSelector mAttrList;
        internal nsCSSSelector mNext;

        internal void AddClass (string aClass)
        {
            if (aClass != "")
                mClassList.Last.mNext = new nsAtomList(aClass);
        }

        internal void AddID (string aID)
        {
            if (aID != "")
                mIDList.Last.mNext = new nsAtomList(aID);
        }

        internal void AddAttribute (int aNameSpace, string aAttr, nsAttrFunc aFunc, string aValue, bool aCaseSensitive)
        {
            AddAttributeInternal(new nsAttrSelector(aNameSpace, aAttr, aFunc, aValue, aCaseSensitive));
        }

        internal void AddAttribute (int aNameSpace, string aAttr)
        {
            AddAttributeInternal(new nsAttrSelector(aNameSpace, aAttr));
        }

        internal void AddAttributeInternal (nsAttrSelector aAttribute)
        {
            mAttrList.Last.mNext = aAttribute;
        }

        internal void AddPseudoClass (nsCSSPseudoClass aType, string aString)
        {
            AddPseudoClassInternal(new nsPseudoClassList(aType, aString));
        }

        internal void AddPseudoClass (nsCSSPseudoClass aType, int[] aIntPair)
        {
            AddPseudoClassInternal(new nsPseudoClassList(aType, aIntPair));
        }

        internal void AddPseudoClass (nsCSSPseudoClass aType, nsCSSSelectorList aSelectorList)
        {
            AddPseudoClassInternal(new nsPseudoClassList(aType, aSelectorList));
        }

        internal void AddPseudoClass (nsCSSPseudoClass aType)
        {
            AddPseudoClassInternal(new nsPseudoClassList(aType));
        }

        internal void AddPseudoClassInternal (nsPseudoClassList aPseudoClass)
        {
            mPseudoClassList.Last.mNext = aPseudoClass;
        }

        internal bool IsPseudoElement ()
        {
            return mLowercaseTag != null && mCasedTag == null;
        }

        internal void SetNameSpace (int aNameSpace)
        {
            mNameSpace = aNameSpace;
        }

        internal void SetOperator (char aOperator)
        {
            mOperator = aOperator;
        }

        internal void SetPseudoType (nsCSSPseudoElement aPseudoType)
        {
            mPseudoType = aPseudoType;
        }

        internal void SetTag (string aTag)
        {
            if (aTag == "") {
                mLowercaseTag = mCasedTag = null;
                return;
            }
            mCasedTag = String.Intern(aTag);
            mLowercaseTag = String.Intern(aTag.ToLower());
        }

        internal int CalcWeight ()
        {
            return 0; // not supported (complex code, likely to change)
        }

        // Public interface

        public string Tag
        {
            get { return mCasedTag ?? mLowercaseTag; }
        }

        public string TagCased
        {
            get { return mCasedTag; }
        }

        public string TagLower
        {
            get { return mLowercaseTag; }
        }

        public int NamespaceId
        {
            get { return mNameSpace; }
        }

        public string NamespaceUri
        {
            get { return nsNameSpaceManager.Instance.GetNameSpaceURI(mNameSpace); }
        }

        public char Operator
        {
            get { return mOperator; }
        }

        public IEnumerable<nsCSSSelector> Negations
        {
            get { return mNegations.Items; }
        }

        public nsCSSPseudoElement PseudoType
        {
            get { return mPseudoType; }
        }

        public IEnumerable<string> Ids
        {
            get { return mIDList.Items; }
        }

        public IEnumerable<string> Classes
        {
            get { return mClassList.Items; }
        }

        public IEnumerable<nsPseudoClassList> PseudoClasses
        {
            get { return mPseudoClassList.Items; }
        }

        public IEnumerable<nsAttrSelector> Attrs
        {
            get { return mAttrList.Items; }
        }

        internal IEnumerable<nsCSSSelector> Items
        {
            get { return this.TraverseList(i => i.mNext); }
        }
    }
}