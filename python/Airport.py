# Airport handles multiple Hangers
from Hanger import Hanger


class Airport:
    def __init__(self, location):
        self.location = str(location)
        self.hangers = []
        self.hanger_num = 0

    def create_hanger(self):
        self.hangers.append(Hanger(self, self.hanger_num))
        self.hanger_num += 1

    def print(self):
        print(self.location)
        for hanger in self.hangers:
            hanger.print()
            print("\n")
