﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Permissions;
using System.Runtime.Serialization;
using Microsoft.Kinect;

namespace KinectSerializer
{
    [Serializable]
    public class SerializableJoint : ISerializable
    {
        public const string NameTrackingState = "TrackingState";
        public const string NameJointType = "Type";
        public const string NameCamperaSpacePoint = "CameraSpacePoint";
        public const string NameDepthSpacePoint = "DepthSpacePoint";
        public const string NameOrientation = "Orientation";

        private TrackingState trackingState;

        public TrackingState TrackingState
        {
            get
            {
                return this.trackingState;
            }
        }

        private JointType type;

        public JointType JointType
        {
            get
            {
                return this.type;
            }
        }

        private CameraSpacePoint cameraSpacePoint;

        public CameraSpacePoint CameraSpacePoint
        {
            get
            {
                return this.cameraSpacePoint;
            }
        }

        private DepthSpacePoint depthSpacePoint;
        
        public DepthSpacePoint DepthSpacePoint
        {
            get
            {
                return this.depthSpacePoint;
            }
        }

        private JointOrientation orientation;
        public JointOrientation JointOrientation
        {
            get
            {
                return this.orientation;
            }
        }

        public SerializableJoint(TrackingState trackingState, JointType type, CameraSpacePoint cameraSpacePoint, DepthSpacePoint depthSpacePoint, JointOrientation orientation)
        {
            this.trackingState = trackingState;
            this.type = type;
            this.cameraSpacePoint = cameraSpacePoint;
            this.depthSpacePoint = depthSpacePoint;
            this.orientation = orientation;
        }

        protected SerializableJoint(SerializationInfo info, StreamingContext ctx)
        {
            this.trackingState = (TrackingState)info.GetValue(SerializableJoint.NameTrackingState, typeof(TrackingState));
            this.type = (JointType)info.GetValue(SerializableJoint.NameJointType, typeof(JointType));
            this.cameraSpacePoint = (CameraSpacePoint)info.GetValue(SerializableJoint.NameCamperaSpacePoint, typeof(CameraSpacePoint));
            this.depthSpacePoint = (DepthSpacePoint)info.GetValue(SerializableJoint.NameDepthSpacePoint, typeof(DepthSpacePoint));
            this.orientation = (JointOrientation)info.GetValue(SerializableJoint.NameOrientation, typeof(JointOrientation));
        }

        [SecurityPermission(SecurityAction.Demand, SerializationFormatter = true)]
        public void GetObjectData(SerializationInfo info, StreamingContext ctx)
        {
            info.AddValue(SerializableJoint.NameTrackingState, this.trackingState, typeof(TrackingState));
            info.AddValue(SerializableJoint.NameJointType, this.type, typeof(JointType));
            info.AddValue(SerializableJoint.NameCamperaSpacePoint, this.cameraSpacePoint, typeof(CameraSpacePoint));
            info.AddValue(SerializableJoint.NameDepthSpacePoint, this.depthSpacePoint, typeof(DepthSpacePoint));
            info.AddValue(SerializableJoint.NameOrientation, this.orientation, typeof(JointOrientation));
        }
    }
}
