from os import system
import csv
system("cls")

file = open("otos.csv")
csvreader = csv.reader(file)

sorok = []
for sor in csvreader:
    sorok.append(sor)

file.close()

# korábbi sorsolások
# múlt heti

multheti_szamok_sor = str(sorok[0]).split(";")



print(f"Múlt heti nyerőszámok: {sorok[0]}")