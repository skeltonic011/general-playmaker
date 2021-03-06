// Custom Action by DumbGameDev
// www.dumbgamedev.com

using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
	[ActionCategory(ActionCategory.Transform)]
	[Tooltip("Calculate the direction between two vectors with the option to normalize.")]

	public class DirectionBetweenVector3 : FsmStateAction
	{

        [RequiredField]
		[Title ("Source")]
		[Tooltip("Source Vector.")]
		public FsmVector3 source;

		[RequiredField]
		[Title ("Target")]
        [Tooltip("Target Vector.")]
		public FsmVector3 target;

		[UIHint(UIHint.Variable)]
		[Title ("Direction")]
		[Tooltip("Direction between the two vectors.")]
		public FsmVector3 direction;

		public FsmBool everyFrame;

		[ActionSection ("Normalize")]

		[Tooltip("Normaize the direction between these two vector3s using distance. Only enable when needed as this does an extra step of calculation.")]
		public FsmBool normalize;

		[UIHint(UIHint.Variable)]
		[Title ("Distance")]
		[Tooltip("Distance between the two vectors is only calculated when normalize is toggled.")]
		public FsmFloat distance;

		[UIHint(UIHint.Variable)]
		[Title ("Direction Normalized")]
		[Tooltip("Direction between vectors3 normalized. Also known as heading")]
		public FsmVector3 directionNormalized;

		private Vector3 _direction;

        public override void Reset()
		{

			target = null;
			direction = null;
			distance = null;
			directionNormalized = null;
			normalize = false;
			source = null;
			everyFrame = false;
		}

		public override void OnEnter()
		{

			doDirection();

			if (!everyFrame.Value)
			{
				Finish();
			}

		}

        public override void OnUpdate()
		{
			if (everyFrame.Value)
			{
               doDirection();
			}
		}

		void doDirection()
		{

			if (!normalize.Value) {

				direction.Value = target.Value - source.Value;

			}

			if (normalize.Value) {
				
				// Do normal direction calculations
				direction.Value = target.Value - source.Value;
				_direction = direction.Value;

				//Distance is calculated by the direction magnitude
				distance.Value = _direction.magnitude;

				//Normalized direction
				directionNormalized.Value = direction.Value / distance.Value;

			}
            
        }

	}
}