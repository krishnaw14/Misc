# coding: utf-8
from traits.api import *
from traitsui.api import View, Item, ButtonEditor
class Calculator(HasTraits):
    val1=Complex()
    val2=Complex()
    add=Button()
    sub=Button()
    mult=Button()
    div=Button()
    val=Complex()
    def _add_fired(self):
        self.val=self.val1+self.val2
    def _sub_fired(self):
        self.val=self.val1-self.val2
    def _mult_fired(self):
        self.val=self.val1*self.val2
    def _div_fired(self):
        self.val=self.val1/self.val2
    view=View('val1', 'val2', 'val', Item('add', show_label=False), Item('sub', show_label=False), Item('mult', show_label=False), Item('div', show_label=False))
                
Calculator().configure_traits()
