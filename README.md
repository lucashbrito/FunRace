Issue
========
Given the following log of a go-kart race:

```text
Time                               Pilot                  No    Lap Time Lap       Average turn speed
23:49:08.277      038 – F.MASSA                           1		1:02.852                        44,275
23:49:10.858      033 – R.BARRICHELLO                     1		1:04.352                        43,243
23:49:11.075      002 – K.RAIKKONEN                       1             1:04.108                        43,408
23:49:12.667      023 – M.WEBBER                          1		1:04.414                        43,202
23:49:30.976      015 – F.ALONSO                          1		1:18.456			35,47
23:50:11.447      038 – F.MASSA                           2		1:03.170                        44,053
23:50:14.860      033 – R.BARRICHELLO                     2		1:04.002                        43,48
23:50:15.057      002 – K.RAIKKONEN                       2             1:03.982                        43,493
23:50:17.472      023 – M.WEBBER                          2		1:04.805                        42,941
23:50:37.987      015 – F.ALONSO                          2		1:07.011			41,528
23:51:14.216      038 – F.MASSA                           3		1:02.769                        44,334
23:51:18.576      033 – R.BARRICHELLO		          3		1:03.716                        43,675
23:51:19.044      002 – K.RAIKKONEN                       3		1:03.987                        43,49
23:51:21.759      023 – M.WEBBER                          3		1:04.287                        43,287
23:51:46.691      015 – F.ALONSO                          3		1:08.704			40,504
23:52:01.796      011 – S.VETTEL                          1		3:31.315			13,169
23:52:17.003      038 – F.MASS                            4		1:02.787                        44,321
23:52:22.586      033 – R.BARRICHELLO		          4		1:04.010                        43,474
23:52:22.120      002 – K.RAIKKONEN                       4		1:03.076                        44,118
23:52:25.975      023 – M.WEBBER                          4		1:04.216                        43,335
23:53:06.741      015 – F.ALONSO                          4		1:20.050			34,763
23:53:39.660      011 – S.VETTEL                          2		1:37.864			28,435
23:54:57.757      011 – S.VETTEL                          3		1:18.097			35,633

```

Resultado esperado
------------------
* From an input of a log file of the format above, assemble the result of the race with the following information: ** Arrival Position **, ** Pilot Code **, ** Pilot Name **, ** Qty of Completed Laps ** and ** Total Race Time **.
Comments
------------
* The first line of the file can be disregarded (Hour, Pilot, Number of Lap, Lap Time, Average speed of the lap).
* The race ends when the first place finishes 4 laps

Bonus
-----
Not obligatory. Do it only if you identify with the problem or if you think there is something interesting to be shown in the solution

**********************************************
* Find the best lap for each driver
***********************************************
* Find the best lap of the race
************************************************
* Calculate the average speed of each driver throughout the race
**************************************************** **********************
* Find out how long each driver arrived after the winner

SOLUTION
=======
* The solution can be developed in any language of your choice;
* Be creative;
* Another person will be reading what you have done, so remember to try to bring the semantics of the problem into your code;
* It is not necessary to use any framework, try to use the language resources;

WE WOULD LIKE TO SEE
==================
* Clean code;
* Immutability (when possible);
* Error Handling;
* Clear separation of responsibilities (Domains, Services, Repositories, etc.);
* Ensure the quality of your code;
