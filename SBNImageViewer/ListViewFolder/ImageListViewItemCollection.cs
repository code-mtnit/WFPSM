﻿// ImageListView - A listview control for image files
// Copyright (C) 2009 Ozgur Ozcitak
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//
//     http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
//
// Ozgur Ozcitak (ozcitak@yahoo.com)

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Collections;
using System.Windows.Forms;
using System.Drawing;

namespace Sbn.AdvancedControls.Imaging.ImageViewer.ListViewFolder
{
    public partial class ImageListView
    {
        /// <summary>
        /// Represents the collection of items in the image list view.
        /// </summary>
        public class ImageListViewItemCollection : IList<ImageListItem>, ICollection, IList, IEnumerable
        {
            #region Member Variables
            private List<ImageListItem> mItems;
            internal ImageListView mImageListView;
            private ImageListItem mFocused;
            #endregion

            #region Constructors
            /// <summary>
            /// Initializes a new instance of the ImageListViewItemCollection class.
            /// </summary>
            /// <param name="owner">The ImageListView owning this collection.</param>
            internal ImageListViewItemCollection(ImageListView owner)
            {
                mItems = new List<ImageListItem>();
                mFocused = null;
                mImageListView = owner;
            }
            #endregion

            #region Properties
            /// <summary>
            /// Gets the number of elements contained in the <see cref="T:System.Collections.Generic.ICollection`1"/>.
            /// </summary>
            public int Count
            {
                get { return mItems.Count; }
            }
            /// <summary>
            /// Gets a value indicating whether the <see cref="T:System.Collections.Generic.ICollection`1"/> is read-only.
            /// </summary>
            public bool IsReadOnly
            {
                get { return false; }
            }
            /// <summary>
            /// Gets or sets the focused item.
            /// </summary>
            public ImageListItem FocusedItem
            {
                get
                {
                    return mFocused;
                }
                set
                {
                    ImageListItem oldFocusedItem = mFocused;
                    mFocused = value;
                    // Refresh items
                    if (oldFocusedItem != mFocused && mImageListView != null)
                        mImageListView.Refresh();
                }
            }
            /// <summary>
            /// Gets the ImageListView owning this collection.
            /// </summary>
            [Category("Behavior"), Browsable(false), Description("Gets the ImageListView owning this collection.")]
            public ImageListView ImageListView { get { return mImageListView; } }
            /// <summary>
            /// Gets or sets the item at the specified index.
            /// </summary>
            [Category("Behavior"), Browsable(false), Description("Gets or sets the item at the specified index.")]
            public ImageListItem this[int index]
            {
                get
                {
                    return mItems[index];
                }
                set
                {
                    ImageListItem item = value;

                    if (mItems[index] == mFocused)
                        mFocused = item;
                    bool oldSelected = mItems[index].Selected;
                    item.mIndex = index;
                    if (mImageListView != null)
                        item.mImageListView = mImageListView;
                    item.owner = this;
                    mItems[index] = item;

                    if (mImageListView != null)
                    {
                        if (mImageListView.CacheMode == CacheMode.Continuous)
                        {
                            if (item.isVirtualItem)
                                mImageListView.cacheManager.Add(item.Guid, item.VirtualItemKey,
                                    mImageListView.ThumbnailSize, mImageListView.UseEmbeddedThumbnails);
                            else
                                mImageListView.cacheManager.Add(item.Guid, item.FileName,
                                    mImageListView.ThumbnailSize, mImageListView.UseEmbeddedThumbnails);
                        }
                        mImageListView.itemCacheManager.Add(item);
                        if (item.Selected != oldSelected)
                            mImageListView.OnSelectionChangedInternal();
                    }
                }
            }
            /// <summary>
            /// Gets the item with the specified Guid.
            /// </summary>
            [Category("Behavior"), Browsable(false), Description("Gets or sets the item with the specified Guid.")]
            internal ImageListItem this[Guid guid]
            {
                get
                {
                    foreach (ImageListItem item in this)
                        if (item.Guid == guid) return item;
                    throw new ArgumentException("No item with this guid exists.", "guid");
                }
            }
            #endregion

            #region Instance Methods
            /// <summary>
            /// Adds an item to the <see cref="T:System.Collections.Generic.ICollection`1"/>.
            /// </summary>
            /// <param name="item">The object to add to the <see cref="T:System.Collections.Generic.ICollection`1"/>.</param>
            public void Add(ImageListItem item)
            {
                AddInternal(item);

                if (mImageListView != null)
                {
                    if (item.Selected)
                        mImageListView.OnSelectionChangedInternal();
                    mImageListView.Refresh();
                }
            }
            /// <summary>
            /// Adds an item to the <see cref="T:System.Collections.Generic.ICollection`1"/>.
            /// </summary>
            /// <param name="filename">The name of the image file.</param>
            public void Add(string filename)
            {
                Add(new ImageListItem(filename));
            }
            /// <summary>
            /// Adds a virtual item to the <see cref="T:System.Collections.Generic.ICollection`1"/>.
            /// </summary>
            /// <param name="key">The key identifying the item.</param>
            /// <param name="text">Text of the item.</param>
            public void Add(object key, string text)
            {
                Add(key, text, null);
            }
            /// <summary>
            /// Adds a virtual item to the <see cref="T:System.Collections.Generic.ICollection`1"/>.
            /// </summary>
            /// <param name="key">The key identifying the item.</param>
            /// <param name="text">Text of the item.</param>
            /// <param name="initialThumbnail">The initial thumbnail image for the item.</param>
            public void Add(object key, string text, Image initialThumbnail)
            {
                ImageListItem item = new ImageListItem(key, text);
                if (mImageListView != null && initialThumbnail != null)
                {
                    mImageListView.cacheManager.Add(item.Guid, key, mImageListView.ThumbnailSize,
                        initialThumbnail, mImageListView.UseEmbeddedThumbnails);
                }
                Add(item);
            }
            /// <summary>
            /// Adds a range of items to the <see cref="T:System.Collections.Generic.ICollection`1"/>.
            /// </summary>
            /// <param name="items">The items to add to the collection.</param>
            public void AddRange(ImageListItem[] items)
            {
                if (mImageListView != null)
                    mImageListView.mRenderer.SuspendPaint();

                foreach (ImageListItem item in items)
                    Add(item);

                if (mImageListView != null)
                {
                    mImageListView.Refresh();
                    mImageListView.mRenderer.ResumePaint();
                }
            }
            /// <summary>
            /// Adds a range of items to the <see cref="T:System.Collections.Generic.ICollection`1"/>.
            /// </summary>
            /// <param name="filenames">The names or the image files.</param>
            public void AddRange(string[] filenames)
            {
                if (mImageListView != null)
                    mImageListView.mRenderer.SuspendPaint();

                for (int i = 0; i < filenames.Length; i++)
                {
                    Add(filenames[i]);
                }

                if (mImageListView != null)
                {
                    mImageListView.Refresh();
                    mImageListView.mRenderer.ResumePaint();
                }

            }

            /// <summary>
            /// Adds a range of items to the <see cref="T:System.Collections.Generic.ICollection`1"/>.
            /// </summary>
            /// <param name="filenames">The names or the image files.</param>
            public void AddRange(System.Collections.ObjectModel.Collection<string> filenames)
            {
                if (mImageListView != null)
                    mImageListView.mRenderer.SuspendPaint();

                foreach (string str in  filenames)
                {
                    Add(str);
                }

                if (mImageListView != null)
                {
                    mImageListView.Refresh();
                    mImageListView.mRenderer.ResumePaint();
                }

            }
            /// <summary>
            /// Removes all items from the <see cref="T:System.Collections.Generic.ICollection`1"/>.
            /// </summary>
            public void Clear()
            {
                if (mImageListView != null)
                {
                    mImageListView.cacheManager.Clear();
                    mImageListView.Refresh();
                }
                mItems.Clear();
                mFocused = null;
            }
            /// <summary>
            /// Determines whether the <see cref="T:System.Collections.Generic.ICollection`1"/> contains a specific value.
            /// </summary>
            /// <param name="item">The object to locate in the <see cref="T:System.Collections.Generic.ICollection`1"/>.</param>
            /// <returns>
            /// true if <paramref name="item"/> is found in the <see cref="T:System.Collections.Generic.ICollection`1"/>; otherwise, false.
            /// </returns>
            public bool Contains(ImageListItem item)
            {
                return mItems.Contains(item);
            }
            /// <summary>
            /// Returns an enumerator that iterates through the collection.
            /// </summary>
            /// <returns>
            /// A <see cref="T:System.Collections.Generic.IEnumerator`1"/> that can be used to iterate through the collection.
            /// </returns>
            public IEnumerator<ImageListItem> GetEnumerator()
            {
                return mItems.GetEnumerator();
            }
            /// <summary>
            /// Inserts an item to the <see cref="T:System.Collections.Generic.IList`1"/> at the specified index.
            /// </summary>
            /// <param name="index">The zero-based index at which <paramref name="item"/> should be inserted.</param>
            /// <param name="item">The object to insert into the <see cref="T:System.Collections.Generic.IList`1"/>.</param>
            /// <exception cref="T:System.ArgumentOutOfRangeException">
            /// 	<paramref name="index"/> is not a valid index in the <see cref="T:System.Collections.Generic.IList`1"/>.
            /// </exception>
            public void Insert(int index, ImageListItem item)
            {
                InsertInternal(index, item);

                if (mImageListView != null)
                {
                    if (item.Selected)
                        mImageListView.OnSelectionChangedInternal();
                    mImageListView.Refresh();
                }
            }
            /// <summary>
            /// Removes the first occurrence of a specific object from the <see cref="T:System.Collections.Generic.ICollection`1"/>.
            /// </summary>
            /// <param name="item">The object to remove from the <see cref="T:System.Collections.Generic.ICollection`1"/>.</param>
            /// <returns>
            /// true if <paramref name="item"/> was successfully removed from the <see cref="T:System.Collections.Generic.ICollection`1"/>; otherwise, false. This method also returns false if <paramref name="item"/> is not found in the original <see cref="T:System.Collections.Generic.ICollection`1"/>.
            /// </returns>
            public bool Remove(ImageListItem item)
            {
                for (int i = item.mIndex; i < mItems.Count; i++)
                    mItems[i].mIndex--;
                if (item == mFocused) mFocused = null;
                bool ret = mItems.Remove(item);
                if (mImageListView != null)
                {
                    mImageListView.cacheManager.Remove(item.Guid);
                    if (item.Selected)
                        mImageListView.OnSelectionChangedInternal();
                    mImageListView.Refresh();
                }
                return ret;
            }
            /// <summary>
            /// Removes the <see cref="T:System.Collections.Generic.IList`1"/> item at the specified index.
            /// </summary>
            /// <param name="index">The zero-based index of the item to remove.</param>
            /// <exception cref="T:System.ArgumentOutOfRangeException">
            /// 	<paramref name="index"/> is not a valid index in the <see cref="T:System.Collections.Generic.IList`1"/>.
            /// </exception>
            public void RemoveAt(int index)
            {
                Remove(mItems[index]);
            }
            #endregion

            #region Helper Methods

            public void Move(ImageListItem item, int index)
            {
                int oldeindex = IndexOf(item);

                if (index == oldeindex)
                    return;

                Remove(item);
                Insert(index, item);

            }
            /// <summary>
            /// Adds the given item without raising a selection changed event.
            /// </summary>
            internal void AddInternal(ImageListItem item)
            {
                // Check if the file already exists
                if (mImageListView != null && !item.isVirtualItem)// && !mImageListView.AllowDuplicateFileNames)
                {
                   // if (System.IO.File.Exists(item.FileName))
                     if (mItems.Exists(a => string.Compare(a.FileName, item.FileName, StringComparison.OrdinalIgnoreCase) == 0))
                        return;
                }
                item.owner = this;
                item.mIndex = mItems.Count;
                mItems.Add(item);
                if (mImageListView != null)
                {
                    item.mImageListView = mImageListView;

                    if (mImageListView.CacheMode == CacheMode.Continuous)
                    {
                        if (item.isVirtualItem)
                            mImageListView.cacheManager.Add(item.Guid, item.VirtualItemKey,
                                mImageListView.ThumbnailSize, mImageListView.UseEmbeddedThumbnails);
                        else
                            mImageListView.cacheManager.Add(item.Guid, item.FileName,
                                mImageListView.ThumbnailSize, mImageListView.UseEmbeddedThumbnails);
                    }

                    mImageListView.itemCacheManager.Add(item);
                }
            }
            /// <summary>
            /// Inserts the given item without raising a selection changed event.
            /// </summary>
            internal void InsertInternal(int index, ImageListItem item)
            {
                // Check if the file already exists
                if (mImageListView != null && !mImageListView.AllowDuplicateFileNames)
                {
                    if (mItems.Exists(a => string.Compare(a.FileName, item.FileName, StringComparison.OrdinalIgnoreCase) == 0))
                        return;
                }
                item.owner = this;
                item.mIndex = index;
                for (int i = index; i < mItems.Count; i++)
                    mItems[i].mIndex++;
                mItems.Insert(index, item);
                if (mImageListView != null)
                {
                    item.mImageListView = mImageListView;

                    if (mImageListView.CacheMode == CacheMode.Continuous)
                    {
                        if (item.isVirtualItem)
                            mImageListView.cacheManager.Add(item.Guid, item.VirtualItemKey,
                                mImageListView.ThumbnailSize, mImageListView.UseEmbeddedThumbnails);
                        else
                            mImageListView.cacheManager.Add(item.Guid, item.FileName,
                                mImageListView.ThumbnailSize, mImageListView.UseEmbeddedThumbnails);
                    }

                    mImageListView.itemCacheManager.Add(item);
                }
            }
            /// <summary>
            /// Removes the given item without raising a selection changed event.
            /// </summary>
            /// <param name="item">The item to remove.</param>
            internal void RemoveInternal(ImageListItem item)
            {
                RemoveInternal(item, true);
            }
            /// <summary>
            /// Removes the given item without raising a selection changed event.
            /// </summary>
            /// <param name="item">The item to remove.</param>
            /// <param name="removeFromCache">true to remove item image from cache; otherwise false.</param>
            internal void RemoveInternal(ImageListItem item, bool removeFromCache)
            {
                for (int i = item.mIndex; i < mItems.Count; i++)
                    mItems[i].mIndex--;
                if (item == mFocused) mFocused = null;
                if (removeFromCache && mImageListView != null)
                    mImageListView.cacheManager.Remove(item.Guid);
                mItems.Remove(item);
            }
            /// <summary>
            /// Returns the index of the specified item.
            /// </summary>
            internal int IndexOf(ImageListItem item)
            {
                return item.Index;
            }
            /// <summary>
            /// Returns the index of the item with the specified Guid.
            /// </summary>
            internal int IndexOf(Guid guid)
            {
                for (int i = 0; i < mItems.Count; i++)
                    if (mItems[i].Guid == guid) return i;
                return -1;
            }
           
            #endregion

            #region ImageListViewItemComparer
            /// <summary>
            /// Compares items by the sort order and sort column of the owner.
            /// </summary>
            private class ImageListViewItemComparer : IComparer<ImageListItem>
            {
                private ColumnType mSortColumn;
                private SortOrder mOrder;

                public ImageListViewItemComparer(ColumnType sortColumn, SortOrder order)
                {
                    mSortColumn = sortColumn;
                    mOrder = order;
                }

                /// <summary>
                /// Compares two objects and returns a value indicating whether one is less than, equal to, or greater than the other.
                /// </summary>
                public int Compare(ImageListItem x, ImageListItem y)
                {
                    int sign = (mOrder == SortOrder.Ascending ? 1 : -1);
                    int result = 0;
                    switch (mSortColumn)
                    {
                        case ColumnType.DateAccessed:
                            result = DateTime.Compare(x.DateAccessed, y.DateAccessed);
                            break;
                        case ColumnType.DateCreated:
                            result = DateTime.Compare(x.DateCreated, y.DateCreated);
                            break;
                        case ColumnType.DateModified:
                            result = DateTime.Compare(x.DateModified, y.DateModified);
                            break;
                        case ColumnType.Dimensions:
                            long ax = x.Dimensions.Width * x.Dimensions.Height;
                            long ay = y.Dimensions.Width * y.Dimensions.Height;
                            result = (ax < ay ? -1 : (ax > ay ? 1 : 0));
                            break;
                        case ColumnType.FileName:
                            result = string.Compare(x.FileName, y.FileName, StringComparison.InvariantCultureIgnoreCase);
                            break;
                        case ColumnType.FilePath:
                            result = string.Compare(x.FilePath, y.FilePath, StringComparison.InvariantCultureIgnoreCase);
                            break;
                        case ColumnType.FileSize:
                            result = (x.FileSize < y.FileSize ? -1 : (x.FileSize > y.FileSize ? 1 : 0));
                            break;
                        case ColumnType.FileType:
                            result = string.Compare(x.FileType, y.FileType, StringComparison.InvariantCultureIgnoreCase);
                            break;
                        case ColumnType.Name:
                            result = string.Compare(x.Text, y.Text, StringComparison.InvariantCultureIgnoreCase);
                            break;
                        case ColumnType.Resolution:
                            float rx = x.Resolution.Width * x.Resolution.Height;
                            float ry = y.Resolution.Width * y.Resolution.Height;
                            result = (rx < ry ? -1 : (rx > ry ? 1 : 0));
                            break;
                        case ColumnType.ImageDescription:
                            result = string.Compare(x.ImageDescription, y.ImageDescription, StringComparison.InvariantCultureIgnoreCase);
                            break;
                        case ColumnType.EquipmentModel:
                            result = string.Compare(x.EquipmentModel, y.EquipmentModel, StringComparison.InvariantCultureIgnoreCase);
                            break;
                        case ColumnType.DateTaken:
                            result = DateTime.Compare(x.DateTaken, y.DateTaken);
                            break;
                        case ColumnType.Artist:
                            result = string.Compare(x.Artist, y.Artist, StringComparison.InvariantCultureIgnoreCase);
                            break;
                        case ColumnType.Copyright:
                            result = string.Compare(x.Copyright, y.Copyright, StringComparison.InvariantCultureIgnoreCase);
                            break;
                        case ColumnType.ExposureTime:
                            result = string.Compare(x.ExposureTime, y.ExposureTime, StringComparison.InvariantCultureIgnoreCase);
                            break;
                        case ColumnType.FNumber:
                            result = (x.FNumber < y.FNumber ? -1 : (x.FNumber > y.FNumber ? 1 : 0));
                            break;
                        case ColumnType.ISOSpeed:
                            result = (x.ISOSpeed < y.ISOSpeed ? -1 : (x.ISOSpeed > y.ISOSpeed ? 1 : 0));
                            break;
                        case ColumnType.ShutterSpeed:
                            result = string.Compare(x.ShutterSpeed, y.ShutterSpeed, StringComparison.InvariantCultureIgnoreCase);
                            break;
                        case ColumnType.Aperture:
                            result = string.Compare(x.Aperture, y.Aperture, StringComparison.InvariantCultureIgnoreCase);
                            break;
                        case ColumnType.UserComment:
                            result = string.Compare(x.UserComment, y.UserComment, StringComparison.InvariantCultureIgnoreCase);
                            break;
                        default:
                            result = 0;
                            break;
                    }
                    return sign * result;
                }
            }
            #endregion

            #region Unsupported Interface
            /// <summary>
            /// Copies the elements of the <see cref="T:System.Collections.Generic.ICollection`1"/> to an <see cref="T:System.Array"/>, starting at a particular <see cref="T:System.Array"/> index.
            /// </summary>
            void ICollection<ImageListItem>.CopyTo(ImageListItem[] array, int arrayIndex)
            {
                mItems.CopyTo(array, arrayIndex);
            }
            /// <summary>
            /// Determines the index of a specific item in the <see cref="T:System.Collections.Generic.IList`1"/>.
            /// </summary>
            [Obsolete("Use ImageListViewItem.Index property instead.")]
            int IList<ImageListItem>.IndexOf(ImageListItem item)
            {
                return mItems.IndexOf(item);
            }
            /// <summary>
            /// Copies the elements of the <see cref="T:System.Collections.ICollection"/> to an <see cref="T:System.Array"/>, starting at a particular <see cref="T:System.Array"/> index.
            /// </summary>
            void ICollection.CopyTo(Array array, int index)
            {
                if (!(array is ImageListItem[]))
                    throw new ArgumentException("An array of ImageListViewItem is required.", "array");
                mItems.CopyTo((ImageListItem[])array, index);
            }
            /// <summary>
            /// Gets the number of elements contained in the <see cref="T:System.Collections.Generic.ICollection`1"/>.
            /// </summary>
            int ICollection.Count
            {
                get { return mItems.Count; }
            }
            /// <summary>
            /// Gets a value indicating whether access to the <see cref="T:System.Collections.ICollection"/> is synchronized (thread safe).
            /// </summary>
            bool ICollection.IsSynchronized
            {
                get { return false; }
            }
            /// <summary>
            /// Gets an object that can be used to synchronize access to the <see cref="T:System.Collections.ICollection"/>.
            /// </summary>
            object ICollection.SyncRoot
            {
                get { throw new NotSupportedException(); }
            }
            /// <summary>
            /// Adds an item to the <see cref="T:System.Collections.IList"/>.
            /// </summary>
            int IList.Add(object value)
            {
                if (!(value is ImageListItem))
                    throw new ArgumentException("An object of type ImageListViewItem is required.", "value");
                ImageListItem item = (ImageListItem)value;
                Add(item);
                return mItems.IndexOf(item);
            }
            /// <summary>
            /// Determines whether the <see cref="T:System.Collections.IList"/> contains a specific value.
            /// </summary>
            bool IList.Contains(object value)
            {
                if (!(value is ImageListItem))
                    throw new ArgumentException("An object of type ImageListViewItem is required.", "value");
                return mItems.Contains((ImageListItem)value);
            }
            /// <summary>
            /// Returns an enumerator that iterates through a collection.
            /// </summary>
            /// <returns>
            /// An <see cref="T:System.Collections.IEnumerator"/> object that can be used to iterate through the collection.
            /// </returns>
            System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
            {
                return mItems.GetEnumerator();
            }
            /// <summary>
            /// Determines the index of a specific item in the <see cref="T:System.Collections.IList"/>.
            /// </summary>
            int IList.IndexOf(object value)
            {
                if (!(value is ImageListItem))
                    throw new ArgumentException("An object of type ImageListViewItem is required.", "value");
                return IndexOf((ImageListItem)value);
            }
            /// <summary>
            /// Inserts an item to the <see cref="T:System.Collections.IList"/> at the specified index.
            /// </summary>
            void IList.Insert(int index, object value)
            {
                if (!(value is ImageListItem))
                    throw new ArgumentException("An object of type ImageListViewItem is required.", "value");
                Insert(index, (ImageListItem)value);
            }
            /// <summary>
            /// Gets a value indicating whether the <see cref="T:System.Collections.IList"/> has a fixed size.
            /// </summary>
            bool IList.IsFixedSize
            {
                get { return false; }
            }
            /// <summary>
            /// Removes the first occurrence of a specific object from the <see cref="T:System.Collections.IList"/>.
            /// </summary>
            void IList.Remove(object value)
            {
                if (!(value is ImageListItem))
                    throw new ArgumentException("An object of type ImageListViewItem is required.", "value");
                Remove((ImageListItem)value);
            }
            /// <summary>
            /// Gets or sets the <see cref="System.Object"/> at the specified index.
            /// </summary>
            object IList.this[int index]
            {
                get
                {
                    return this[index];
                }
                set
                {
                    if (!(value is ImageListItem))
                        throw new ArgumentException("An object of type ImageListViewItem is required.", "value");
                    this[index] = (ImageListItem)value;
                }
            }
            #endregion
        }
    }
}