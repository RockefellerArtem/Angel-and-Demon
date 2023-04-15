mergeInto(LibraryManager.library, {
  InitPurchases: function() {
    initPayments();
  },

  Purchase: function(id) {
    buy(Pointer_stringify(id));
  },

  GetInfoDeviceType: function(){
    getInfoDeviceType();
  },

  GetCurrentLanguageToDomen: function(){
    currentLanguage();
  },

  AuthenticateUser: function() {
    auth();
  },

  SaveData: function(data) {
    save(Pointer_stringify(data));
  },

  LoadData: function() {
    load();
  },
  
  CanReviewGame: function(){
	canReviewGame();
  },

  SetLeaderboard: function(name, count, description){
  	setLeaderboard(name, count, description);
  },

  GetLeaderboard: function(name){
  	getLeaderboard(name);
  },

  GetLeaderboards: function(name, count){
  	getLeaderboards(name, count);
  },

  CurrentLanguage: function(){
	currentLanguage();
  },

  GetUserData: function() {
    getUserData();
  },

  ShowFullscreenAd: function () {
    showFullscrenAd();
  },

  ShowRewardedAd: function(placement) {
    showRewardedAd(placement);
    return placement;
  },

  OpenWindow: function(link){
    var url = Pointer_stringify(link);
      document.onmouseup = function()
      {
        window.open(url);
        document.onmouseup = null;
      }
  }
});