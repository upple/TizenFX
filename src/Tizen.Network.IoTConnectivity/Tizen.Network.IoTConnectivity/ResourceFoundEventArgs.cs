 /*
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

namespace Tizen.Network.IoTConnectivity
{
    /// <summary>
    /// This class represents event arguments of the ResourceFound event.
    /// </summary>
    /// <since_tizen>3</since_tizen>
    public class ResourceFoundEventArgs : EventArgs
    {
        internal ResourceFoundEventArgs() { }

        /// <summary>
        /// Indicates the request id.
        /// This is the same request id returned by the <see cref="IoTConnectivityClientManager.StartFindingResource()"/> API.
        /// </summary>
        /// <since_tizen>3</since_tizen>
        /// <value>The request id.</value>
        public int RequestId { get; internal set; }

        /// <summary>
        /// Indicates to continuously receive the event for finding resource.
        /// </summary>
        /// <since_tizen>3</since_tizen>
        /// <value>Continuously receive the event for finding resource.</value>
        public bool EventContinue { get; set; }

        /// <summary>
        /// Remote resource which is found after <see cref="IoTConnectivityClientManager.StartFindingResource()"/>.
        /// </summary>
        /// <since_tizen>3</since_tizen>
        /// <value>Remote resource which is found after <see cref="IoTConnectivityClientManager.StartFindingResource()"/>.</value>
        /// <seealso cref="IoTConnectivityClientManager.ResourceFound"/>
        /// <seealso cref="IoTConnectivityClientManager.StartFindingResource()"/>
        public RemoteResource Resource { get; internal set; }
    }
}
