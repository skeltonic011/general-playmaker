// Custom Action by DumbGameDev
// www.dumbgamedev.com

using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
    [ActionCategory("Line Renderer")]
    [Tooltip("Change line renderer texture mode.")]

	public class setLineRendererTextureMode : FsmStateAction
	{

     	[RequiredField]
		[CheckForComponent(typeof(LineRenderer))]
		[Tooltip("Gameobject holding the line renderer.")]
		public FsmOwnerDefault gameObject;

		public FsmBool enableStretch;
		public FsmBool everyFrame;

        // private variables
		
		private LineTextureMode textureModeStretch = LineTextureMode.Stretch;
		private LineTextureMode textureModeTile = LineTextureMode.Tile;

     	private LineRenderer lr;

     	public override void Reset()
		{

			enableStretch = false;
			gameObject = null;
			everyFrame = false;
		}

		public override void OnEnter()
		{
			var go = Fsm.GetOwnerDefaultTarget(gameObject);
            lr = go.GetComponent<LineRenderer>();


            if (!everyFrame.Value)
			{
				DoChange();
				Finish();
			}

        }

        public override void OnUpdate()
		{
			if (everyFrame.Value)
			{
                DoChange();
			}
		}

		void DoChange()
		{
			var go = Fsm.GetOwnerDefaultTarget(gameObject);
			if (go == null)
			{
				return;
			}

			if (!enableStretch.Value) {
				
				lr.textureMode = textureModeTile;
			}
			
			else {
				
				lr.textureMode = textureModeStretch;
			}
			
        }

	}
}