var QQ = {
    uid: null,
    token: null,
    init: function() {
        if (typeof QQUser_id !== 'undefined') {
            this.uid = QQUser_id;
        } else if (typeof window.jinterface !== 'undefined' && typeof window.jinterface.getUserID !== 'undefined') {
            this.uid = window.jinterface.getUserID();
        } else {
            this.uid = null;
        }

        if (typeof QQToken !== 'undefined') {
            this.token = QQToken;
        } else if (typeof window.jinterface !== 'undefined' && typeof window.jinterface.getToken !== 'undefined') {
            this.token = window.jinterface.getToken();
        } else {
            this.token = null;
        }
    }
};
QQ.init();