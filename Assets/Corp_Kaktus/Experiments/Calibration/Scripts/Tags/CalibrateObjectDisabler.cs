using UnityEngine;

namespace Corp_Kaktus.Experiments.Calibration.Scripts.Tags
{
    [RequireComponent(typeof(Calibrator))]
    public class CalibrateObjectDisabler : MonoBehaviour
    {
        private void Start()
        {
            var calibrator = GetComponent<Calibrator>();
            
            calibrator.onCalibrateStart.AddListener(() => { SetActive(false);});
            calibrator.onCalibrateEnd.AddListener(() => { SetActive(true);});
        }

        public void SetActive(bool active)
        {
            var cTags = FindObjectsByType<DisableWhenCalibrateTag>(FindObjectsInactive.Include,FindObjectsSortMode.None);
           
            foreach (var cTag in cTags)
            {
                cTag.gameObject.SetActive(active);
            }
        }
    }
}