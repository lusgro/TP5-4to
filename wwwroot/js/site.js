function startTimer() {
    var startTime = localStorage.getItem("startTime");
    var timerDuration = 3600000; // Set timer duration to 1 hour
    if (!startTime || startTime < new Date().getTime() - timerDuration) {
      startTime = new Date().getTime() + timerDuration; // Set start time to current time plus timer duration
      localStorage.setItem("startTime", startTime);
    } else {
      startTime = parseInt(startTime); // Convert start time to integer
    }
    var intervalId;
    
    // Function to update the timer
    function updateTimer() {
      var remainingTime = startTime - new Date().getTime();
      if (remainingTime < 0) {
        remainingTime = 0;
      }
      var minutes = Math.floor((remainingTime % 3600000) / 60000).toString().padStart(2, "0");
      var seconds = Math.floor((remainingTime % 60000) / 1000).toString().padStart(2, "0");
      document.getElementById("timer").innerHTML = minutes + ":" + seconds;
      if (remainingTime == 0) {
        clearInterval(intervalId);
      }
    }
    
    // Check if the timer has already expired
    if (startTime - new Date().getTime() > 0) {
      updateTimer();
      intervalId = setInterval(updateTimer, 1000);
    } else {
      localStorage.removeItem("startTime"); // Remove the stored start time
      updateTimer(); // Reset the timer to default
    }
  }