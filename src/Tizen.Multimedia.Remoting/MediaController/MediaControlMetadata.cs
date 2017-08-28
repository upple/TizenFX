﻿/*
 * Copyright (c) 2016 Samsung Electronics Co., Ltd All Rights Reserved
 *
 * Licensed under the Apache License, Version 2.0 (the License);
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 *
 * http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an AS IS BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 */

using System;
using System.Diagnostics;
using Native = Interop.MediaControllerClient;

namespace Tizen.Multimedia.Remoting
{
    /// <summary>
    /// Represents metadata for media control.
    /// </summary>
    public class MediaControlMetadata
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MediaControlMetadata"/> class.
        /// </summary>
        public MediaControlMetadata()
        {
        }

        internal MediaControlMetadata(IntPtr handle)
        {
            Debug.Assert(handle != IntPtr.Zero);

            Title = Native.GetMetadata(handle, MediaControllerAttribute.Title);
            Artist = Native.GetMetadata(handle, MediaControllerAttribute.Artist);
            Album = Native.GetMetadata(handle, MediaControllerAttribute.Album);
            Author = Native.GetMetadata(handle, MediaControllerAttribute.Author);
            Genre = Native.GetMetadata(handle, MediaControllerAttribute.Genre);
            Duration = Native.GetMetadata(handle, MediaControllerAttribute.Duration);
            Date = Native.GetMetadata(handle, MediaControllerAttribute.Date);
            Copyright = Native.GetMetadata(handle, MediaControllerAttribute.Copyright);
            Description = Native.GetMetadata(handle, MediaControllerAttribute.Description);
            TrackNumber = Native.GetMetadata(handle, MediaControllerAttribute.TrackNumber);
            AlbumArtPath = Native.GetMetadata(handle, MediaControllerAttribute.Picture);
        }

        /// <summary>
        /// Gets or sets the title.
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Gets or sets the artist.
        /// </summary>
        public string Artist { get; set; }

        /// <summary>
        /// Gets or sets the album.
        /// </summary>
        public string Album { get; set; }

        /// <summary>
        /// Gets or sets the author.
        /// </summary>
        public string Author { get; set; }

        /// <summary>
        /// Gets or sets the genre.
        /// </summary>
        public string Genre { get; set; }

        /// <summary>
        /// Gets or sets the duration.
        /// </summary>
        public string Duration { get; set; }

        /// <summary>
        /// Gets or sets the date.
        /// </summary>
        public string Date { get; set; }

        /// <summary>
        /// Gets or sets the copyright.
        /// </summary>
        public string Copyright { get; set; }

        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the track number.
        /// </summary>
        public string TrackNumber { get; set; }

        /// <summary>
        /// Gets or sets the path of the album art.
        /// </summary>
        public string AlbumArtPath { get; set; }
    }
}