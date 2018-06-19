using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using mygame;

namespace mygame
{
    public class BaseCode : MonoBehaviour
    {

        void Start()
        {
            Controller my = Controller.GetInstance();
            my.setBaseCode(this);
        }
    }
    public class Controller : System.Object, UserActions, QueryGameStatus
    {
        private static Controller _instance;
        private BaseCode _base_code;
        private Model _gen_game_obj;
        private bool moving = false;
        private string message = "";
        public bool ifstart = true;
        public static Controller GetInstance()
        {
            if (null == _instance) _instance = new Controller();
            return _instance;
        }

        public BaseCode getBaseCode() { return _base_code; }
        internal void setBaseCode(BaseCode bc) { if (null == _base_code) _base_code = bc; }

        public Model getGenGameObject() { return _gen_game_obj; }
        internal void setGenGameObject(Model ggo) { if (null == _gen_game_obj) _gen_game_obj = ggo; }

        public bool isMoving() { return moving; }
        public void setMoving(bool state) { this.moving = state; }
        public string getMessage() { return message; }
        public void setMessage(string message) { this.message = message; }

        public void priestSOnB() { _gen_game_obj.priestStartOnBoat(); }
        public void priestEOnB() { _gen_game_obj.priestEndOnBoat(); }
        public void devilSOnB() { _gen_game_obj.devilStartOnBoat(); }
        public void devilEOnB() { _gen_game_obj.devilEndOnBoat(); }
        public void moveBoat() { _gen_game_obj.moveBoat(); }
        public void offBoatL() { _gen_game_obj.getOffTheBoat(0); }
        public void offBoatR() { _gen_game_obj.getOffTheBoat(1); }
        public IEnumerator doNext() { return _gen_game_obj.doNext(); }

        public void restart()
        {
            moving = false;
            message = "";
            ifstart = false;
            _gen_game_obj.reset_all();
            ifstart = true;
        }
    }
    
    
    public interface UserActions
    {
        void priestSOnB();
        void priestEOnB();
        void devilSOnB();
        void devilEOnB();
        void moveBoat();
        void offBoatL();
        void offBoatR();
        void restart();
        IEnumerator doNext();
    }
    public interface QueryGameStatus
    {
        bool isMoving();
        void setMoving(bool state);
        string getMessage();
        void setMessage(string message);
    }

}

