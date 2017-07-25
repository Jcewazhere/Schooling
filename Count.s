     ;************************************************
     ; File: Count 1s and 0s
     ; Programmer: Jamie Edwards
     ; This program counts the number of ones and
     ; zeros in a randomly generated number.
     ; Project: CountOnes
     ; 3/11/14
     ;************************************************
	 ;r2 holds original number for 1Loop
	 ;r3 holds changing number for both loops 
	 ;r4 holds original number for 0Loop
	 ;r5 is the counter
	 ;r6 holds 1s
	 ;************************************************
	 
	 AREA BitsCounter, CODE, READONLY
	      IMPORT randomnumber          ;import the number generator
SWI_WriteC     EQU r0                  ;output r0
SWI_Exit       EQU r11                 ;end program
	     ENTRY
	     BL        randomnumber        ;get the random number
		 MOV       r2, r0              ;copy random number for 1s
		 MOV       r3, r0              ;copy random number for use
		 MOV       r4, r0              ;copy random number for 0s
		 MVN       r6, #0              ;store all 1s to compare
		 BL        Print
		 BL        Count1
		 BL        Print
		 BL        Count0
		 BL        Print
Exit    SWI        SWI_Exit

Count1  MOV        r5, #0              ;reset the counter
        CMP        r2, #0              ;make sure the number isn't 0
        MOVEQ      pc, r14             ;exit if the number is 0
Loop1   ADD        r5, r5, #1          ;increment counter
        SUBS       r3, r2, #1          ;decrement changing number
		AND        r2, r3, r2          ;remove a 1
		CMP        r2, #0              ;check for 0
		BNE        Loop1               ;restart loop
		MOV        r1, r5              ;ready counter for printing
		MOV        pc, r14             ;return to entry
		
Count0  MOV        r5, #0              ;reset counter
		MOV        r3, r0              ;reset changing number
        CMP        r4, r6              ;make sure the number isn't all 1
		MOVEQ      pc, r14             ;exit if number is 0
Loop0   ADDS       r5, r5, #1          ;increment counter
        ADDS       r3, r4, #1          ;add 1 to changing number
		ORR        r4, r4, r3          ;remove a 0    
		CMP        r4, r6              ;check for all 1s
		BNE        Loop0               ;restart loop
		MOV        r1, r5              ;ready counter for printing
		MOV        pc, r14             ;return to entry
		
Print   MOV        r2, #8              ;count of nibble = 8
LOOP    MOV        r0, r1, LSR #28     ;get first nibble
        CMP        r0, #9              
		ADDGT      r0, r0, #"A"-10     ;ASCII alphabet
		ADDLE      r0, r0, #"0"        ;ASCII#
		SWI        SWI_WriteC          ;print character
        MOV        r1, r1, LSL #4      ;left one nibble
        SUBS       r2, r2, #1		   ;decrement nibble
		BNE        LOOP                ;if more loop
		MOV        pc, r14             ;return to entry
		
		END