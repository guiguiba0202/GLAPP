package com.example.glapp;

import android.text.InputFilter;
import android.text.Spanned;

public class NumericInputFilter implements InputFilter {

    @Override
    public CharSequence filter(CharSequence source, int start, int end, Spanned dest, int dstart, int dend) {
        StringBuilder builder = new StringBuilder();

        for (int i = start; i < end; i++) {
            char currentChar = source.charAt(i);
            if (Character.isDigit(currentChar)) {
                builder.append(currentChar);
            }
        }

        return builder.toString();
    }
}