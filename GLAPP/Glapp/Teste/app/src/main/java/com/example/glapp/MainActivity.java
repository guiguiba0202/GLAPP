package com.example.glapp;

import androidx.appcompat.app.AppCompatActivity;

import android.os.AsyncTask;
import android.os.Bundle;
import android.os.TransactionTooLargeException;
import android.util.Log;
import android.view.View;
import android.widget.Button;
import android.widget.EditText;
import android.widget.TextView;
import android.text.InputFilter;
import android.text.Spanned;

public class MainActivity extends AppCompatActivity {
    private Button button;
    private TextView textView;
    //Para armazenar o cep
    private EditText editText;
    private String valorArmazenado;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main);


        editText = findViewById(R.id.editText);
        editText.setFilters(new InputFilter[]{new InputFilter.LengthFilter(8)});
        editText.setFilters(new InputFilter[]{new NumericInputFilter()});


        button = (Button) findViewById(R.id.button);
        textView = (TextView) findViewById(R.id.textView);
        button.setOnClickListener(new View.OnClickListener(){
            @Override
            public void onClick(View v) {
                valorArmazenado = editText.getText().toString();
                String formattedCEP = valorArmazenado.replaceAll("[^\\d]", ""); // Remove caracteres não numéricos

                if (formattedCEP.length() == 8) {
                    Tarefa tarefa = new Tarefa();
                    tarefa.execute("https://viacep.com.br/ws/" + formattedCEP + "/json/");
                } else {
                    textView.setText("CEP inválido");
                }
                /*
                Tarefa tarefa =new Tarefa();
                tarefa.execute("https://viacep.com.br/ws/"+valorArmazenado+"/json/");
                 */
            }
        });
    }

    private class Tarefa extends AsyncTask<String, String, String> {

        @Override
        protected String doInBackground(String... strings) {
            String retorno = Conexao.getDados(strings[0]);
            return retorno;
        }

        @Override
        protected void onPostExecute(String s) {
            if (s.contains("true")) {
                textView.setText("Este CEP não existe");
            } else {
                textView.setText(s);
            }

        }
    }
}