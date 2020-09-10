package com.example.doanandroid;

import android.content.Intent;
import android.os.Bundle;
import android.view.View;
import android.widget.Button;

import androidx.appcompat.app.AppCompatActivity;

public class DatHangThanhCongActivity extends AppCompatActivity {

    Button btnthanhcong;
    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_thanhcong);

        btnthanhcong = findViewById(R.id.buttonQuayVeTrangChu);

        btnthanhcong.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                startActivity(new Intent(DatHangThanhCongActivity.this,TrangChuActivity.class));
                finish();
            }
        });
    }
}
